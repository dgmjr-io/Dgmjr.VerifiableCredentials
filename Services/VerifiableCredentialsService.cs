namespace Dgmjr.VerifiableCredentials.Services;

using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using System.Net.Http;
using Dgmjr.Mime;
using Application = Dgmjr.Mime.Application;
using Microsoft.Extensions.Caching.Distributed;
using System.Runtime.Serialization;

/// <summary>A class for manipulating verifiable credentials</summary>
public class VerifiableCredentialsService(
    ILogger<VerifiableCredentialsService> logger,
    IDownstreamApi verifiableCredentialsApp,
    IOptionsMonitor<VerifiableCredentialsIssuerApiOptions> vcIssuerOptions,
    IOptionsMonitor<VerifiableCredentialsAdminApiOptions> vcAdminApiOptions,
    IDistributedCache cache,
    IOptionsMonitor<JsonOptions> jso
) : IVerifiableCredentialsService
{
    public ILogger Logger => logger;
    private readonly IDownstreamApi _verifiableCredentialsApp = verifiableCredentialsApp;
    public VerifiableCredentialsIssuerApiOptions IssuerOptions => vcIssuerOptions.CurrentValue;
    public VerifiableCredentialsAdminApiOptions AdminApiOptions => vcAdminApiOptions.CurrentValue;
    private const string VerifiedEmployee = "Verified Employee";
    private readonly IDistributedCache _cache = cache;
    private Jso JsonSerializerOptions => jso.CurrentValue.JsonSerializerOptions;
    private static readonly DateTimeOffset _absoluteExpiration =
        new(9999, 1, 1, 1, 1, 1, new duration(0, 0, 0));
    private static readonly DistributedCacheEntryOptions _cacheEntryOptions = new() { AbsoluteExpiration = _absoluteExpiration };

    public async Task<VCContract[]> GetVCContractsAsync()
    {
        Logger.LogCallingDownstreamApi(
            VerifiableCredentialsAdminApiOptions.AppSettingsKey,
            IssuerOptions.Urls.Contracts(guid.Parse(IssuerOptions.AuthorityId))
        );
        return (await _cache.GetOrCreateAsync(
            nameof(GetVCContractsAsync),
            async () =>
            {
                Logger.LogCacheMiss(nameof(GetVCContractsAsync));

                var vcs = await _verifiableCredentialsApp.CallApiForUserAsync<
                    ApiResponsePayload<VCContract[]>
                >(
                    VerifiableCredentialsAdminApiOptions.AppSettingsKey,
                    options =>
                    {
                        options.RelativePath = IssuerOptions.Urls.Contracts(
                            guid.Parse(IssuerOptions.AuthorityId)
                        );
                        options.RequestAppToken = true;
                        options.Deserializer = content =>
                            content
                                .ReadAsStringAsync()
                                .ContinueWith(task =>
                                {
                                    Logger.LogInformation(task.Result);
                                    return Deserialize<ApiResponsePayload<VCContract[]>>(
                                        task.Result,
                                        JsonSerializerOptions
                                    );
                                })
                                .Result;
                    }
                );
                return vcs.Value
                                .Where(
                                    vc =>
                                        !vc.Name.Equals(VerifiedEmployee, CurrentCultureIgnoreCase)
                                )
                                .ToArray();
            },
            _cacheEntryOptions
        ))!;
    }

    public async Task<(
        string Name,
        string Instructions,
        guid AuthorityId,
        string Id,
        VCLogo Logo
    )[]> GetVCsAsync()
    {
        return (await GetVCContractsAsync())
            .Select(
                vc =>
                    (
                        vc.Name,
                        vc.Displays[0].Consent.Instructions,
                        vc.AuthorityId,
                        vc.Id,
                        vc.Displays[0].Card.Logo
                    )
            )
            .ToArray();
    }

    public async Task<VCLogo> GetCredentialIconAsync(string? credentialId)
    {
        var cacheKey = $"{GetCredentialIconAsync}({credentialId})";
        return (await _cache.GetOrCreateAsync(
            cacheKey,
            async () =>
            {
                Logger.LogCacheMiss(cacheKey);
                var (_, _, _, _, logo) = Find(
                    await GetVCsAsync(),
                    vc => vc.Id.Equals(credentialId, CurrentCultureIgnoreCase)
                );
                return logo;
            },
            _cacheEntryOptions
        ))!;
    }

    public async Task<IImage> GetResizedCredentialIconAsync(string? credentialId, int maxDimension)
    {
        try
        {
            return (await GetCredentialIconAsync(credentialId)).Image.Downsize(maxDimension);
        }
        catch (PlatformNotSupportedException)
        {
            Logger.LogPlatformNotSupported(nameof(GetResizedCredentialIconAsync));
            return (await GetCredentialIconAsync(credentialId)).Image;
        }
    }

    public async Task<byte[]> GetResizedCredentialIconBytesAsync(
        string? credentialId,
        int maxDimension
    ) => await (await GetResizedCredentialIconAsync(credentialId, maxDimension)).AsBytesAsync();

    public async Task<VCAuthority[]> GetAuthoritiesAsync()
    {
        Logger.LogCallingDownstreamApi(
            VerifiableCredentialsAdminApiOptions.AppSettingsKey,
            IssuerOptions.Urls.Authorities
        );
        return (await _cache.GetOrCreateAsync(
            nameof(GetAuthoritiesAsync),
            async () =>
            {
                Logger.LogCacheMiss(nameof(GetAuthoritiesAsync));
                var authorities = await _verifiableCredentialsApp.CallApiForUserAsync<
                    ApiResponsePayload<VCAuthority[]>
                >(
                    VerifiableCredentialsAdminApiOptions.AppSettingsKey,
                    options =>
                    {
                        options.RelativePath = IssuerOptions.Urls.Authorities;
                        options.RequestAppToken = true;
                        options.Deserializer = content =>
                            content
                                .ReadAsStringAsync()
                                .ContinueWith(task =>
                                {
                                    Logger.LogInformation(task.Result);
                                    return Deserialize<ApiResponsePayload<VCAuthority[]>>(
                                        task.Result,
                                        JsonSerializerOptions
                                    );
                                })
                                .Result;
                    }
                );
                return authorities.Value;
            },
            _cacheEntryOptions
        ))!;
    }

    public async Task<VCIssuanceRequestResponse> SendIssuanceRequestAsync(VCIssuanceRequest request)
    {
        return (await _verifiableCredentialsApp.CallApiForAppAsync<VCIssuanceRequestResponse>(
            VerifiableCredentialsIssuerApiOptions.AppSettingsKey,
            options =>
            {
                options.Scopes = [Scopes.Issuer];
                options.HttpMethod = HttpMethod.Post.ToString();
                options.RelativePath = IssuerOptions.Urls.CreateIssuanceRequest;
                options.Serializer = value =>
                {
                    var content = new StringContent(Serialize(value, JsonSerializerOptions));
                    content.Headers.ContentType = new(Application.Json.DisplayName);
                    return content;
                };
                options.CustomizeHttpRequestMessage = message =>
                {
                    message.Content = new StringContent(Serialize(request, JsonSerializerOptions));
                    message.Content.Headers.ContentType = new(Application.Json.DisplayName);
                };
                options.Deserializer = content =>
                    content
                        .ReadAsStringAsync()
                        .ContinueWith(task =>
                        {
                            Logger.LogInformation(task.Result);
                            return Deserialize<ApiResponsePayload<VCIssuanceRequestResponse>>(
                                task.Result,
                                JsonSerializerOptions
                            );
                        })
                        .Result;

                Logger.LogCallingDownstreamApi(
                    VerifiableCredentialsIssuerApiOptions.AppSettingsKey,
                    options.GetApiUrl(),
                    Serialize(request, JsonSerializerOptions)
                );
            }
        ))!;
    }

    public async Task<VCAuthority> CreateAuthorityAsync(VCAuthorityCreateDto createDto)
    {
        Logger.LogCallingDownstreamApi(
            VerifiableCredentialsAdminApiOptions.AppSettingsKey,
            IssuerOptions.Urls.Authorities,
            createDto
        );
        return (await _verifiableCredentialsApp.CallApiForAppAsync<VCAuthority>(
            VerifiableCredentialsAdminApiOptions.AppSettingsKey,
            options =>
            {
                options.RelativePath = IssuerOptions.Urls.Authorities;
                options.RequestAppToken = true;
                options.Deserializer = content =>
                    content
                        .ReadAsStringAsync()
                        .ContinueWith(task =>
                        {
                            Logger.LogInformation(task.Result);
                            return Deserialize<ApiResponsePayload<VCAuthority[]>>(
                                task.Result,
                                JsonSerializerOptions
                            ).Value[0];
                        })
                        .Result;
            }
        ))!;
    }

    public VCIssuanceRequest CreateIssuanceRequest(guid contractId, Uri callbackUrl, string stateId, CustomClaimMapper? customClaimMapper)
    {
        var selectedContract = Find(
            GetVCContractsAsync().Result,
            vc => vc.Id.Equals(contractId.ToString(), CurrentCultureIgnoreCase)
        );
        return new VCIssuanceRequest
        {
            IncludeQRCode = true,
            Authority = IssuerOptions.IssuerAuthority,
            Registration = new VCRequestRegistration()
            {
                ClientName = IssuerOptions.ClientName,
                Purpose = selectedContract.Displays[0].Card.Description,
                LogoUrl = selectedContract.Displays[0].Card.Logo.Uri
            },
            Callback = new VCCallback()
            {
                Url = callbackUrl,
                State = stateId,
                Headers = new StringDictionary() { { "api-key", IssuerOptions.ApiKey } }
            },
            Type = selectedContract.Rules.VC.Type.Join(","),
            Manifest = selectedContract.ManifestUrl,
            Pin = IssuerOptions.PinLength > 0 ? new VCPin()
                {
                    Length = IssuerOptions.PinLength,
                    Value = Format(
                        "{0:D" + IssuerOptions.PinLength.ToString() + "}",
                        RandomNumberGenerator.GetInt32(
                            1,
                            int.Parse("".PadRight(IssuerOptions.PinLength, '9'))
                        )
                    )
                } : default,
            Claims = customClaimMapper?.Invoke(selectedContract.Rules.Attestations) ?? new StringDictionary()
        };
    }
}

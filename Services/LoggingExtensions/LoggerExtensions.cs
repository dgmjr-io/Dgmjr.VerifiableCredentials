namespace Dgmjr.VerifiableCredentials.Services;

using Microsoft.Extensions.Logging;
using static Microsoft.Extensions.Logging.LogLevel;

internal static partial class LoggerExtensions
{
    [LoggerMessage(Information, "Cache miss for key {key}", EventName = "CacheMiss")]
    public static partial void LogCacheMiss(this ILogger logger, string key);

    [LoggerMessage(Information, "Cache hit for key {key}", EventName = "CacheHit")]
    public static partial void LogCacheHit(this ILogger logger, string key);

    [LoggerMessage(
        Warning,
        "Platform not supported for operation: {Operation}",
        EventName = "PlatformNotSupported"
    )]
    public static partial void LogPlatformNotSupported(this ILogger logger, string operation);

    [LoggerMessage(
        Information,
        "Calling downstream API {APIName} {url} with correlationId {correlationId} and payload {payload}",
        EventName = "CallingDownstreamApi"
    )]
    public static partial void LogCallingDownstreamApi(
        this ILogger logger,
        string apiName,
        string url,
        object? payload = default,
        string? correlationId = default
    );
}

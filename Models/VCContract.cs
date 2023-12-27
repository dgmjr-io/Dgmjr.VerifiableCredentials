namespace Dgmjr.VerifiableCredentials.Models;

public record class VCContract
{
    public string Id { get; set; }
    public string Name { get; set; }
    public guid AuthorityId { get; set; }
    public VCContractStatus Status { get; set; }
    public Uri ManifestUrl { get; set; }
    public bool IssueNotificationEnabled { get; set; }
    public guid[] IssueNotificationAllowedToGroupOids { get; set; }
    public bool AvailableInVcDirectory { get; set; }
    public VCDisplay[] Displays { get; set; }
    public VCRules Rules { get; set; }
}

public enum VCContractStatus
{
    Enabled
}

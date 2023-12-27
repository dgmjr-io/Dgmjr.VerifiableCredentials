namespace Dgmjr.VerifiableCredentials.Models
{
    public record class VCClaimMapping
    {
        [JProp("inputClaim")]
        public string InputClaim { get; set; }

        [JProp("outputClaim")]
        public string OutputClaim { get; set; }

        [JProp("claim")]
        public string Claim { get; set; }

        [JProp("type")]
        public string Type { get; set; }

        [JProp("required")]
        public bool IsRequired { get; set; }

        [JProp("indexed")]
        public bool IsIndexed { get; set; }
    }
}

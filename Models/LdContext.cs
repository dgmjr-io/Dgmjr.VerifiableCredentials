namespace Dgmjr.VerifiableCredentials.Models;

public class LdContext : OneOf.OneOfBase<Uri, LdContextBase>
{
    public LdContext(Uri value) : base(value) { }
    public LdContext(LdContextBase value) : base(value) { }
}

public class LdContextBase
{
    [JProp("@base")]
    public Uri Base { get; set; }
}

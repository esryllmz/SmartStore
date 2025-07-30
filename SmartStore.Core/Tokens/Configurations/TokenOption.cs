namespace SmartStore.Core.Tokens.Configurations;

public class TokenOption
{
    public string Issuer { get; set; } = default!;
    public List<string> Audience { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; } = default!;

}

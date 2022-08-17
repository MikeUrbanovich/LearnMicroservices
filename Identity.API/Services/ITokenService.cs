namespace Identity.API.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName, UserRole userRole);
    }
}

namespace KAMU.API.Infrastructure.Services.Security
{
    public interface IAccessManager
    {
        bool AuthenticateAsync(string email, string password);
    }
}

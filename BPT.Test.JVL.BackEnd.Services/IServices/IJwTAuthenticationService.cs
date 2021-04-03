namespace BPT.Test.JVL.BackEnd.Services.IServices
{
    public interface IJwTAuthenticationService
    {
        string Authenticate(string name, string password);
    }
}

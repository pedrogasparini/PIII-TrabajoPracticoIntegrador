using Application.Models.Request;


namespace Application.Interfaces
{
    public interface ICustomAuthenticationService
    {
        string Authenticate(AuthenticationRequest authenticationRequest);
    }
}
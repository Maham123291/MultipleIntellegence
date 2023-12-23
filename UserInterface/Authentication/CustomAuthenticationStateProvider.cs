using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using DataAccessLayer;
using UserInterface.Authentication;
using System.Linq.Expressions;



namespace UserInterface.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            try
            {
                var userSessionStorageResult = await
                    _sessionStorage.GetAsync<UserSessions>("UserSessions");
                var userSessions = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSessions == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>

            {
                new Claim(ClaimTypes.Name,userSessions.username),

                 new Claim(ClaimTypes.NameIdentifier,userSessions.userid),
            new Claim(ClaimTypes.Role,userSessions.roles)
            ,}, "CustomAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));

            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));



            }


        }
       public async Task UpdateAuthenticationState(UserSessions userSessions)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSessions != null)
            {
               await _sessionStorage.SetAsync("UserSessions", userSessions); // Set the new session data

                claimsPrincipal = new ClaimsPrincipal(
                    new ClaimsIdentity(new List<Claim>
    {
        new Claim(ClaimTypes.Name, userSessions.username),

        new Claim(ClaimTypes.NameIdentifier, userSessions.userid),

        new Claim(ClaimTypes.Role,userSessions.roles,userSessions.username==null?"": "verified") // Use a static role for authenticated users
    }));
            }
            else
            {await _sessionStorage.DeleteAsync("UserSessions"); // Remove the old session data

                claimsPrincipal=_anonymous; // Create an 
                
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


    }
}

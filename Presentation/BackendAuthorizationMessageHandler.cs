using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Presentation
{
    public class BackendAuthorizationMessageHandler: AuthorizationMessageHandler
    {
        public BackendAuthorizationMessageHandler(IAccessTokenProvider provider,
                                                  NavigationManager navigation) 
            : base(provider, navigation)
        {
            ConfigureHandler(new[] { "https://localhost:6001/" });
        }
    }
}
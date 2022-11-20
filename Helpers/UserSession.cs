using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace Mi_Granjita_Paraiso.Helpers
{
    public class UserSession
    {
        public string UserName { get; }
        public string Id { get; set; }
        public string Email { get; set; }

        public UserSession(ClaimsPrincipal user)
        {
            UserName = user.FindFirstValue("userName");
            Id = user.FindFirstValue("id");
            Email = user.FindFirstValue("email");
        }
    }
}

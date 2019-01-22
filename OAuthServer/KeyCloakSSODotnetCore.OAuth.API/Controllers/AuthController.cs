using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KeyCloakSSODotnetCore.Helpers.HttpClient.Service;
using KeyCloakSSODotnetCore.Helpers.HttpClient.Implementation;
using KeyCloakSSODotnetCore.Helpers.KeyCloakDomain;
using Newtonsoft.Json;
using KeyCloakSSODotnetCore.Helpers.KeyCloakServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KeyCloakSSODotnetCore.OAuth.API.Controllers
{

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        KeyCloakOAuthAPIConfig _keyCloakOptions;
        public AuthController(KeyCloakOAuthAPIConfig keyCloakOptions)
        {
            _keyCloakOptions = keyCloakOptions;
        }
        [HttpPost]
        [Route("login")]
        public ActionResult<AccessTokenResponse> Login([FromBody]UserLogin user)
        {
            if (user.Username == "kaan" && user.Password == "kaan")
            {
                return KeyCloakService.GetAccessToken(_keyCloakOptions); 
            }
            return Unauthorized();
        }
    }
}

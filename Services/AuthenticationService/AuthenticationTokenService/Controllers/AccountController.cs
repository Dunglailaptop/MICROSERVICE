
using LibraryAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryAuthentication.Models;

namespace AuthenticationTokenService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler jwtTokenHandlers;

        public AccountController(JwtTokenHandler _jwtTokenHandler)
        {
            jwtTokenHandlers = _jwtTokenHandler;                                     
        }

        [HttpPost]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest request)
        {
            var Authentication = jwtTokenHandlers.GenerateJwToken(request);
            if (Authentication == null) return Unauthorized();
            return Authentication;
        }
    }
}

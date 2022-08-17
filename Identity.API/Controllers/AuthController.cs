using Identity.API.Data;
using Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserRepository _userRepository;

        public AuthController(ILogger<AuthController> logger, ITokenService tokenService, IConfiguration configuration, UserRepository userRepository)
        {
            _logger = logger;
            _tokenService = tokenService;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserValidationRequestModel userModel)
        {
            var user = _userRepository.GetUser(userModel.UserName);

            if (user != null)
            {
                var token = _tokenService.BuildToken(
                    _configuration["Jwt:Key"],
                    _configuration["Jwt:Issuer"],
                    new[]
                    {
                        _configuration["Jwt:Aud1"],
                        _configuration["Jwt:Aud2"]
                    },
                    user.Username,
                    user.Role
                    );

                return Ok( new
                {
                    Token = token,
                    IsAuthenticated = true,
                });
            }

            return Unauthorized(new
            {
                Token = string.Empty,
                IsAuthenticated = false
            });
        }
    }
}
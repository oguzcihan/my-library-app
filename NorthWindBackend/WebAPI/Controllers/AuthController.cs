using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message); //giriş başarılı değilse
            }

            var result=_authService.CreateAccessToken(userToLogin.Data); //token üretildi
            if (result.Success)
            {
                return Ok(result.Data); //giriş başarılı
            }

            return BadRequest(result.Message); //yanlış ise bad request meshaı verilir
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExist(userForRegisterDto.Email);//user var mı kontrollü
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto,userForRegisterDto.Password); //kayıt edildi
            var result = _authService.CreateAccessToken(registerResult.Data); //token üretildi
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}

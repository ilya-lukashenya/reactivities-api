

namespace API.Controllers
{
    [ApiController]
    [Rout("api/[controller]")]
    public class AccountController : ControllersBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> UserManager, TokenService tokenService) {
            _userManager = userManager
        }

        [HttPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();
            vzr result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if(result) {
                return new UserDto {
                    DisplayName = user.DisplayName,
                    Image = null,
                    Token = _tokenService.CreateToken(user),
                    Username = user.UserName
                };
            }
            return Unauthorized();
        }
    }
}
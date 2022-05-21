using DataAL.DatabaseModels;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressBookBL.DTOs.User;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Address_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

 

        #region Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {
            var newUser = new User
            {
                UserName = registerDTO.Username,
                Address = registerDTO.Address,
                DateOfBirth = registerDTO.DateOfBirth,
                Email = registerDTO.Email
            };

            var creationResult = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var creatingClaimsResult = await _userManager.AddClaimsAsync(newUser, new List<Claim>
                 {
                        new Claim (ClaimTypes.NameIdentifier, newUser.UserName),
                        new Claim (ClaimTypes.Email, newUser.Email),
                        new Claim("Address", newUser.Address),
                        new Claim(ClaimTypes.Email, newUser.Email)

                 });

            if (!creatingClaimsResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry try again");
            }


            return Ok();
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user is null)
            {
                return Unauthorized("Email or password are wrong");
            }

            var isLocked = await _userManager.IsLockedOutAsync(user);
            if (isLocked)
            {
                return Unauthorized("You're locked. Please try again later");
            }

            var isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenticated)
            {
                await _userManager.AccessFailedAsync(user);
                return Unauthorized("Password or Email Wrong");
            }

            var userClaims = await _userManager.GetClaimsAsync(user);

            return GenerateToken(userClaims.ToList());
        }
        #endregion

        #region Helpers
        private TokenDTO GenerateToken(List<Claim> userClaims)
        {
            #region Getting Secret Key ready
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(secretKeyInBytes);
            #endregion

            #region Combining Secret Key with Hashing Algorithm
            var methodUsedInGeneratingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            #endregion

            #region Putting all together (Define the token)
            var jwt = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.Now.AddDays(30),
                notBefore: DateTime.Now,
                issuer: "AuthServer1",
                audience: "Service1",
                signingCredentials: methodUsedInGeneratingToken);
            #endregion

            #region Generate the defined Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var resultToken = tokenHandler.WriteToken(jwt);
            #endregion

            return new TokenDTO
            {
                Token = resultToken,
                ExpiryDate = jwt.ValidTo
            };
        }
        #endregion
    }
}

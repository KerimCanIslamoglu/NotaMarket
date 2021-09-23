using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.Identity;
using NotaMarket.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/[controller]/Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );


                return Ok(new IdentityResponse
                {
                    Success = true,
                    Code = 200,
                    Message = "Giriş başarılı !",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return StatusCode(StatusCodes.Status401Unauthorized, new IdentityResponse
            {
                Success = false,
                Code = 401,
                Message = "Giriş başarısız !",
                Token = null,
            });

        }
        [HttpPost]
        [Route("api/[controller]/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
                {
                    Success = false,
                    Code = 500,
                    Message = "Bu kullanıcı mevcut!",
                    Token = null,
                });
            }

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            var userRoleResult = await _userManager.AddToRoleAsync(user, UserRoles.User);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
                {
                    Success = false,
                    Code = 500,
                    Message = "Kullanıcı oluşturulurken hata oluştu!",
                    Token = null,
                });
            }

            if (!userRoleResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
                {
                    Success = false,
                    Code = 500,
                    Message = "Kullanıcı rolü oluşturulurken hata oluştu!",
                    Token =null,
                });
            }

            var userLogin = await _userManager.FindByNameAsync(model.Username);
            if (userLogin != null && await _userManager.CheckPasswordAsync(userLogin, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                //authClaims.Add(new Claim(ClaimTypes.Role, UserRoles.User));
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new IdentityResponse
                {
                    Success =true,
                    Code=200,
                    Message = "Kullanıcı başarıyla oluşturuldu!",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new IdentityResponse
            {
                Success = false,
                Code = 500,
                Message = "Kullanıcı oluşturulurken hata oluştu!",
                Token = null,
            });
        }




        [HttpPost]
        [Route("api/[controller]/CreateRole")]
        public async Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            var doesRoleExist = await _roleManager.FindByNameAsync(roleModel.RoleName);

            if (doesRoleExist != null)
            {
                return BadRequest(new ResponseObjectModel<string>
                {
                    Success = false,
                    StatusCode = 400,
                    Message = $"{roleModel.RoleName} adlı rol daha önce oluşturulmuş.",
                    Response = null
                });
            }

            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole { Name = roleModel.RoleName });
            if (result.Succeeded)
            {
                return Ok(new ResponseObjectModel<string>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = $"{roleModel.RoleName} rolü başarı ile oluşturuldu.",
                    Response = null
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObjectModel<string>
            {
                Success = false,
                StatusCode = 500,
                Message = $"{roleModel.RoleName} adlı rol oluşturulurken bir hata oluştu.",
                Response = null
            });
        }
    }
}

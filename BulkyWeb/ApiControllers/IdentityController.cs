using BulkyWeb.Application.Services;
using BulkyWeb.Domain.Models;
using BulkyWeb.Models.ViewModels;
using BulkyWeb.Services.Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BulkyWeb.Application.CustomLib.Interfaces;

namespace BulkyWeb.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly _ISerilog _serilog;
        private readonly ICustomLib _ctoLib;
        private async Task CreateCookies(UserInfo user, List<string> authorization)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                    {
                        //new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new(JwtRegisteredClaimNames.Sub, userRole.username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name + " " + user.Surname),
                        //new Claim(ClaimTypes.Role, user.Role.Trim()),
                        new Claim("Position", user.Position),
                    };
                foreach (var item in authorization)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.Trim()));
                }
                //var firstname = user.PrefixName2 + user.FirstName2.Substring(0, 1) + user.FirstName2.Substring(1).ToLower();
                //var lastname = user.LastName2.Substring(0, 1) + user.LastName2.Substring(1).ToLower();
                //var postion = user.PositionLevelName.Split(" ")[0].Trim();
                //var userRole = (user.UnitCodeCode == "442100" || user.UnitCodeCode == "442300") ? "Admin" : postion;
                //List<Claim> claims = new List<Claim>
                //    {
                //        //new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //        //new(JwtRegisteredClaimNames.Sub, userRole.username),
                //        new Claim(ClaimTypes.NameIdentifier, user.EmpCode),
                //        new Claim(ClaimTypes.Name, $"{firstname} {lastname}"),
                //        new Claim(ClaimTypes.Role, userRole),
                //        //new Claim("Position", postion),
                //        new Claim("PositionName", user.PositionNameEN),
                //        new Claim("DeviceName", deviceName)
                //    };

                ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties authenProp = new()
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authenProp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IdentityController(IUnitOfWork unitOfWork
            , _ISerilog serilog
            , ICustomLib ctoLib) 
        {
            _unitOfWork = unitOfWork;
            _serilog = serilog;
            _ctoLib = ctoLib;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            try
            {
                var userAuth = _unitOfWork.UserAuthen.Get(x => x.Email == request.email);
                var verifyPassword = BCrypt.Net.BCrypt.Verify(request.password, userAuth.PasswordHashed);
                if (userAuth != null || !verifyPassword)
                {
                    throw new Exception("email or password is incorrect.");
                }
                
                var userInfo = _unitOfWork.UserInfo.Get(x => x.UserAuthen.Email == request.email);
                var userAuthorize = userInfo.UserAuthorize.Select(x => x.AuthorizationId).ToList();

                await CreateCookies(userInfo, userAuthorize);
                return Ok(new
                {
                    message = "login successful."
                });
            }
            catch (Exception ex)
            {
                _serilog.LogError(ex.Message);
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {

                return Ok(new
                {
                    message = "Register successful."
                });
            }
            catch (Exception ex)
            {

                _serilog.LogError(ex.Message);
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
    }
}

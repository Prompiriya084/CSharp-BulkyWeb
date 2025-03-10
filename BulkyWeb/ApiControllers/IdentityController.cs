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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

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
                //var userAuth = _unitOfWork.UserAuthen.Get(x => x.Email == request.email);
                //var verifyPassword = BCrypt.Net.BCrypt.Verify(request.password, userAuth.PasswordHashed);
                //if (userAuth != null || !verifyPassword)
                //{
                //    throw new Exception("email or password is incorrect.");
                //}
                
                //var userInfo = _unitOfWork.UserInfo.Get(x => x.UserAuthen.Email == request.email);

                //await CreateCookies(userInfo, userInfo.UserAuthorize.Select(x => x.AuthorizationId).ToList());
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
        [Authorize(Policy = "Admin")] //instead Role
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var errValidatePasswordMessage = _ctoLib.Validator.Passowrd(request.Password);
                
                if (!string.IsNullOrWhiteSpace(errValidatePasswordMessage))
                {
                    return BadRequest(new
                    {
                        message = errValidatePasswordMessage
                    });
                }
                if (request.ConfirmPassword != request.Password)
                {
                    return BadRequest(new
                    {
                        message = "Password and confirm password not euqal."
                    });
                }

                var userAuth = _unitOfWork.UserAuthen.Get(x => x.Email == request.Email);
                if (userAuth != null)
                {
                    throw new Exception("this user is exists");
                }
                var dateNow = DateTime.Now;
                var newUserAuth = new UserAuthen();
                newUserAuth.Email = request.Email;
                newUserAuth.PasswordHashed = BCrypt.Net.BCrypt.HashPassword(request.Password);
                newUserAuth.CreatedDate = dateNow;
                newUserAuth.UpdatedDate = dateNow;

                var newUserInfo = new UserInfo();
                newUserInfo.UserAuthenId = newUserAuth.Id;
                newUserInfo.Name = request.Name;
                newUserInfo.Surname = request.Surname;
                newUserInfo.Position = "admin"; //Mock data for testing
                newUserInfo.CreatedDate = dateNow;
                newUserInfo.UpdatedDate = dateNow;

                var newUserAthorizeList = new List<UserAuthorize>();
                foreach (var item in request.AuthorizeId)
                {
                    var newUserAuthorize = new UserAuthorize();
                    newUserAuthorize.UserInfoId = newUserInfo.Id;
                    newUserAuthorize.AuthorizationId = item;
                    newUserAthorizeList.Add(newUserAuthorize);
                }
                _unitOfWork.UserAuthen.Add(newUserAuth);
                _unitOfWork.UserInfo.Add(newUserInfo);
                _unitOfWork.UserAuthorize.AddRange(newUserAthorizeList);
                
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"INSERT INTO UserAuthen | Obj : {JsonConvert.SerializeObject(newUserAuth)}");
                _serilog.LogInformation($"INSERT INTO UserInfo | Obj : {JsonConvert.SerializeObject(newUserInfo)}");
                _serilog.LogInformation($"INSERT INTO UserAuthorize | Obj : {JsonConvert.SerializeObject(newUserAthorizeList)}");

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

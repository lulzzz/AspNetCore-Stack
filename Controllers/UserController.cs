using System;
using AspNetCore_Stack.Auth;
using AspNetCore_Stack.Controllers.Attributes;
using AspNetCore_Stack.Controllers.Views;
using AspNetCore_Stack.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Stack.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [ValidateModel]
    public class UserController : BaseController
    {
        
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }
        
        [HttpPost("Register")]
        public object Register([FromBody] RegisterView view)
        {
            var username = view.Username;
            username = username.Replace(" ", "");

            try
            {
                return _userService.Register(username, view.Password);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("Login")]
        public object Login([FromBody] LoginView loginView)
        {
            try
            {
                return _userService.Login(loginView.Username, loginView.Password);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
        
        [Auth]
        [HttpPost("ChangePassword")]
        public object ChangePassword([FromBody] ChangePasswordView view)
        {
            try
            {
                _userService.ChangePassword(GetUserId(), view.Password, view.OldPassword);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
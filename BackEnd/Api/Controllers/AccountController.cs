using Api.Helper;
using Core.DTOS;
using Core.Services;
using Core.Sharing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        

        public AccountsController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("sign-up")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         var res= await _authService.RegisteAsync(register);
            if (!res.Success)
            {
                if(res.StatusCode==409)
                    return Conflict(new ApiResponse<string>(409, false, res.Message!, null));
                
                return BadRequest(new ApiResponse<string>(400, false, res.Message!, null));
            }
            //return CreatedAtAction(new ApiResponse<object>(201,true,"Done",null);
           return StatusCode(201, new ApiResponse<CreateUserDTO>(201, true, res.Message!, res.Data!));
        }
       
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO) { 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var res=await _authService.LoginAsync(loginDTO);

            if (!res.Success)
            {
                if(res.StatusCode==400)
                    return BadRequest(new ApiResponse<AuthDTO>(400, false, res.Message!, null));
            }
            
            
            return Ok(new ApiResponse<AuthDTO>(200,true,res.Message!,res.Data!));
        
        }

        //[Authorize]
        //[HttpGet("user-info")]
        //public async Task<IActionResult> GetUserInfo()
        //{
        //    var email = User.FindFirst(ClaimTypes.Email);
        //    if (email is null)return Unauthorized(OperationResult.Fail("Unauthorized",null,401));
        //    var user=
        //}
    }
}

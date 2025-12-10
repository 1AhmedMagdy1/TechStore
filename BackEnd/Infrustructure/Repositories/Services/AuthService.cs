using AutoMapper;
using Core.DTOS;
using Core.Models;
using Core.Services;
using Core.Sharing;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Repositories.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper mapper;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            this.mapper = mapper;
        }

        public async Task<OperationResult<CreateUserDTO>> RegisteAsync(RegisterDTO register)
        {
           
            if( await _userManager.FindByEmailAsync(register.Email) is not null)
            {

                return OperationResult<CreateUserDTO>.Fail("This Email Already Exists", new[] { "This Email Already Exists" }, statuscode: 409);
            }
            if (await _userManager.FindByNameAsync(register.UserName) is not null)
            {
               
                return OperationResult<CreateUserDTO>.Fail("This Email Already Exists", new[] { "This Email Already Exists" }, statuscode: 409);

            }
            var user = new AppUser() { 
            Email = register.Email,
            UserName = register.UserName,
            PhoneNumber = register.PhoneNumber
            };
         var res= await  _userManager.CreateAsync(user, register.Password);
            if (res.Succeeded)
            {
                var token = await _tokenService.GenerateToken(user);
                var userDto = mapper.Map<CreateUserDTO>(user);
                userDto.Token = token;
                return OperationResult<CreateUserDTO>.OK(userDto,"Done",201);

            }
            else
            {
                return OperationResult<CreateUserDTO>.Fail("Error in creating User", new[] { res.Errors.FirstOrDefault()!.Description }, statuscode: 400);
            }
        }
        public async Task<OperationResult<AuthDTO>> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email) ;
            if (user is null)
                return  OperationResult<AuthDTO>.Fail("Invalid User name Or Password",new[] { ""},400);

            if(! await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
               
                return OperationResult<AuthDTO>.Fail("Invalid User name Or Password", new[] { "" }, 400);

            }
            // return Token
            var token=await _tokenService.GenerateToken(user);
            var authDto= new AuthDTO()
            {
                Email = user.Email!,
                UserName = user.UserName!,
                Token = token
            };
            return OperationResult<AuthDTO>.OK(authDto,"User Logged in Successfully !",200);


            
        }

        //public async Task<OperationResult<UserInfoDTO>> GetUserInfoAsync(string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user is null) return OperationResult<UserInfoDTO>.Fail("User Not Found", null, 404);

        //}
    }
}

using Core.Sharing;
using Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Services
{
    public interface IAuthService
    {
        Task<OperationResult<CreateUserDTO>> RegisteAsync(RegisterDTO register);
        Task<OperationResult<AuthDTO>> LoginAsync(LoginDTO loginDto);
        //Task<OperationResult<UserInfoDTO>> GetUserInfoAsync(string email);
    }
}

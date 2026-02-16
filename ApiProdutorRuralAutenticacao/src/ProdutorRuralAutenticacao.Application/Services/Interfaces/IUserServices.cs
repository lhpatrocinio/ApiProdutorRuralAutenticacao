using ProdutorRuralAutenticacao.Application.Dtos.Requests;
using ProdutorRuralAutenticacao.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutorRuralAutenticacao.Application.Services.Interfaces
{
    public interface IUserServices
    {
        Task CreateAsync(CreateUserRequest request);
        Task<UserResponse> GetByEmailAsync(GetUserByEmailRequest request);
        Task<UserResponse> GetByNickNameAsync(GetUserByNickNameRequest request);
        Task<UserResponse> GetByIdAsync(GetUserByIdRequest request);
        Task DeleteAsync(DeleteUserRequest request);
        Task BlockUserAsync(BlockUserRequest request);
        Task<List<UserResponse>> ListUsersNoTwoFactor();

    }
}

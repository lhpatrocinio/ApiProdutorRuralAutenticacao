using Microsoft.Extensions.Configuration;
using ProdutorRuralAutenticacao.Application.Dtos.Requests;
using ProdutorRuralAutenticacao.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProdutorRuralAutenticacao.Application.Services.Interfaces
{
    public interface IProdutorRuralAutenticacaoService
    {
        Task<string> LoginAsync(LoginRequest request);

        
    }
}

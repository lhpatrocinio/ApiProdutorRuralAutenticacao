using Asp.Versioning;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProdutorRuralAutenticacao.Application.Dtos.Requests;
using ProdutorRuralAutenticacao.Application.Services.Interfaces;

namespace ProdutorRuralAutenticacao.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProdutorRuralAutenticacaoController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IProdutorRuralAutenticacaoService _authenticationServices;

        public ProdutorRuralAutenticacaoController(IUserServices userServices, IProdutorRuralAutenticacaoService authenticationServices)
        {
            _userServices = userServices;
            _authenticationServices = authenticationServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            await _userServices.CreateAsync(request);

            return Ok(new { message = "Usuário registrado!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Application.Dtos.Requests.LoginRequest request)
        {
            var result = await _authenticationServices.LoginAsync(request);

            if (result is not null)
                return Ok(result);

            return Unauthorized();
        }
    }
}
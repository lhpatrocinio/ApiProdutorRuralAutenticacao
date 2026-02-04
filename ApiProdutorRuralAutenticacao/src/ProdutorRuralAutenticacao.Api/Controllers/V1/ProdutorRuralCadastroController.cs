using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ProdutorRuralAutenticacao.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutorRuralAutenticacaoController : ControllerBase
    {
    }
}

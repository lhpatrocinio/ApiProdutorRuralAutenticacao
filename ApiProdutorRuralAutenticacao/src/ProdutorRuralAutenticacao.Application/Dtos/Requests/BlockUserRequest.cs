using System;

namespace ProdutorRuralAutenticacao.Application.Dtos.Requests
{
    public class BlockUserRequest
    {
        public Guid Id { get; set; }
        public bool EnableBlocking { get; set; }
    }
}

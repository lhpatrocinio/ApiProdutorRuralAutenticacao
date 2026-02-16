using Microsoft.AspNetCore.Identity;
using System;

namespace ProdutorRuralAutenticacao.Domain.Entities.Identity
{
    public class Claims : IdentityRoleClaim<Guid>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

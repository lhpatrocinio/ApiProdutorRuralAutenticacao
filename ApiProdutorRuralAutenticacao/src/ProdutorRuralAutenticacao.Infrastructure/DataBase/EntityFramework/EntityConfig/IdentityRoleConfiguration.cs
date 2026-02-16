using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutorRuralAutenticacao.Domain.Entities.Identity;

namespace ProdutorRuralAutenticacao.Infrastructure.DataBase.EntityFramework.EntityConfig
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("UAC_Roles");
        }

    }
}

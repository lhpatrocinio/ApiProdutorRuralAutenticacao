using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutorRuralAutenticacao.Domain.Entities.Identity;

namespace ProdutorRuralAutenticacao.Infrastructure.DataBase.EntityFramework.EntityConfig
{
    public class IdentityUserClaimConfiguration : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.ToTable("UAC_UserClaims");
        }
    }
}

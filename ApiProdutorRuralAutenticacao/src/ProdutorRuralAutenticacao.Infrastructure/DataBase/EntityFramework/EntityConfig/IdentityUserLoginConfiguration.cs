using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutorRuralAutenticacao.Domain.Entities.Identity;

namespace ProdutorRuralAutenticacao.Infrastructure.DataBase.EntityFramework.EntityConfig
{
    public class IdentityUserLoginConfiguration : IEntityTypeConfiguration<UserLogins>
    {
        public void Configure(EntityTypeBuilder<UserLogins> builder)
        {
            builder.HasKey(u => new { u.LoginProvider, u.ProviderKey, u.UserId });

            builder.Property(u => u.UserId);

            builder.ToTable("UAC_UserLogins");
        }
    }
}

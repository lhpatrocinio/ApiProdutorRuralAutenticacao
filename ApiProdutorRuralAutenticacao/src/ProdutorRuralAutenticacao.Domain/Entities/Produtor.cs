namespace ProdutorRuralAutenticacao.Domain.Entities;

/// <summary>
/// Entidade que representa um Produtor Rural no sistema
/// </summary>
public class Produtor : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Documento { get; set; }
    public TipoDocumento TipoDocumento { get; set; } = TipoDocumento.CPF;
    public bool Ativo { get; set; } = true;
    public bool EmailConfirmado { get; set; } = false;
    public DateTime DataCadastro { get; set; }
    public DateTime? UltimoLogin { get; set; }

    // Navigation
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}

/// <summary>
/// Tipo de documento do produtor
/// </summary>
public enum TipoDocumento
{
    CPF = 1,
    CNPJ = 2
}

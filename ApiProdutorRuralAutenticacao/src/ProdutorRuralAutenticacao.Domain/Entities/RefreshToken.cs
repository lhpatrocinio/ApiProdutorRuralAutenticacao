namespace ProdutorRuralAutenticacao.Domain.Entities;

/// <summary>
/// Entidade que representa um Refresh Token para renovação de JWT
/// </summary>
public class RefreshToken : BaseEntity
{
    public Guid ProdutorId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiraEm { get; set; }
    public bool Revogado { get; set; } = false;

    // Navigation
    public virtual Produtor? Produtor { get; set; }

    /// <summary>
    /// Verifica se o token está expirado
    /// </summary>
    public bool Expirado => DateTime.UtcNow >= ExpiraEm;

    /// <summary>
    /// Verifica se o token é válido (não expirado e não revogado)
    /// </summary>
    public bool Valido => !Expirado && !Revogado;
}

using ProdutorRuralAutenticacao.Domain.Entities;

namespace ProdutorRuralAutenticacao.Domain.Interfaces;

/// <summary>
/// Interface de repositório para RefreshToken
/// </summary>
public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<IEnumerable<RefreshToken>> GetByProdutorIdAsync(Guid produtorId);
    Task RevokeAllByProdutorIdAsync(Guid produtorId);
    Task<RefreshToken?> GetValidTokenByProdutorAsync(Guid produtorId);
}

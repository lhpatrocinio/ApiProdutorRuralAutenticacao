using ProdutorRuralAutenticacao.Domain.Entities;

namespace ProdutorRuralAutenticacao.Domain.Interfaces;

/// <summary>
/// Interface de repositório para Produtor
/// </summary>
public interface IProdutorRepository : IRepository<Produtor>
{
    Task<Produtor?> GetByEmailAsync(string email);
    Task<Produtor?> GetByDocumentoAsync(string documento);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> DocumentoExistsAsync(string documento);
    Task<Produtor?> GetWithRefreshTokensAsync(Guid id);
}

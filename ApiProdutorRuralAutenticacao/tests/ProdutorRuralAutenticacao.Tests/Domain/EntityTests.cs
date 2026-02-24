using FluentAssertions;
using ProdutorRuralAutenticacao.Domain.Entities;

namespace ProdutorRuralAutenticacao.Tests.Domain;

public class RefreshTokenTests
{
    [Fact]
    public void Expirado_QuandoExpiraEmNoPassado_DeveRetornarTrue()
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            ProdutorId = Guid.NewGuid(),
            Token = "abc123",
            ExpiraEm = DateTime.UtcNow.AddMinutes(-1),
            Revogado = false
        };

        token.Expirado.Should().BeTrue();
    }

    [Fact]
    public void Expirado_QuandoExpiraEmNoFuturo_DeveRetornarFalse()
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            ProdutorId = Guid.NewGuid(),
            Token = "abc123",
            ExpiraEm = DateTime.UtcNow.AddHours(1),
            Revogado = false
        };

        token.Expirado.Should().BeFalse();
    }

    [Fact]
    public void Valido_QuandoNaoExpiradoENaoRevogado_DeveRetornarTrue()
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            ProdutorId = Guid.NewGuid(),
            Token = "abc123",
            ExpiraEm = DateTime.UtcNow.AddHours(1),
            Revogado = false
        };

        token.Valido.Should().BeTrue();
    }

    [Fact]
    public void Valido_QuandoExpirado_DeveRetornarFalse()
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            ProdutorId = Guid.NewGuid(),
            Token = "abc123",
            ExpiraEm = DateTime.UtcNow.AddMinutes(-1),
            Revogado = false
        };

        token.Valido.Should().BeFalse();
    }

    [Fact]
    public void Valido_QuandoRevogado_DeveRetornarFalse()
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            ProdutorId = Guid.NewGuid(),
            Token = "abc123",
            ExpiraEm = DateTime.UtcNow.AddHours(1),
            Revogado = true
        };

        token.Valido.Should().BeFalse();
    }

    [Fact]
    public void Valido_QuandoExpiradoERevogado_DeveRetornarFalse()
    {
        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            ProdutorId = Guid.NewGuid(),
            Token = "abc123",
            ExpiraEm = DateTime.UtcNow.AddMinutes(-1),
            Revogado = true
        };

        token.Valido.Should().BeFalse();
    }

    [Fact]
    public void RefreshToken_DeveIniciarComRevogadoFalse()
    {
        var token = new RefreshToken();

        token.Revogado.Should().BeFalse();
    }
}

public class ProdutorEntityTests
{
    [Fact]
    public void Produtor_DeveIniciarComValoresPadrao()
    {
        var produtor = new Produtor();

        produtor.Ativo.Should().BeTrue();
        produtor.EmailConfirmado.Should().BeFalse();
        produtor.TipoDocumento.Should().Be(TipoDocumento.CPF);
        produtor.Nome.Should().BeEmpty();
        produtor.Email.Should().BeEmpty();
    }

    [Fact]
    public void Produtor_DeveTerColecaoRefreshTokens()
    {
        var produtor = new Produtor();

        produtor.RefreshTokens.Should().NotBeNull();
        produtor.RefreshTokens.Should().BeEmpty();
    }

    [Theory]
    [InlineData(TipoDocumento.CPF)]
    [InlineData(TipoDocumento.CNPJ)]
    public void Produtor_TipoDocumentoValidos(TipoDocumento tipo)
    {
        var produtor = new Produtor { TipoDocumento = tipo };

        produtor.TipoDocumento.Should().Be(tipo);
    }
}

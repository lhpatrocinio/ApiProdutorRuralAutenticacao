# 🔐 AgroSolutions - API de Autenticação

Microsserviço responsável pela **autenticação e autorização** dos usuários da plataforma AgroSolutions, emitindo tokens JWT para consumo pelos demais serviços.

## Visão Geral

| Item | Detalhe |
|------|---------|
| **Porta padrão** | 5000 |
| **Banco de dados** | AgroAuth (SQL Server) |
| **Endpoints** | 5 |
| **Testes unitários** | 11 |
| **Autenticação** | JWT Bearer |

## Responsabilidades

- Registro e login de produtores rurais
- Emissão de tokens JWT com claims customizadas (`ProdutorId`, `Role`)
- Validação e renovação de tokens
- Hash seguro de senhas com BCrypt

## Estrutura do Projeto (Clean Architecture)

```
ApiProdutorRuralAutenticacao/
├── ProdutorRuralAutenticacao.Domain/         # Entidades, interfaces, regras de domínio
├── ProdutorRuralAutenticacao.Application/    # Use cases, DTOs, services
├── ProdutorRuralAutenticacao.Infrastructure/ # EF Core, SQL Server, JWT Token Service
├── ProdutorRuralAutenticacao.Api/            # Controllers, middlewares, Swagger
└── ProdutorRuralAutenticacao.Tests/          # Testes unitários (xUnit + Moq)
```

## Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/v1/ProdutorRuralAutenticacao/register` | Cadastra novo usuário |
| `POST` | `/api/v1/ProdutorRuralAutenticacao/login` | Autentica e retorna JWT |
| `POST` | `/api/v1/ProdutorRuralAutenticacao/validate-token` | Valida token JWT |
| `POST` | `/api/v1/ProdutorRuralAutenticacao/refresh-token` | Renova token JWT |
| `GET`  | `/api/v1/ProdutorRuralAutenticacao/me` | Retorna dados do usuário logado |

### Credenciais de seed (desenvolvimento)

```
Email:  admin@fiap.com
Senha:  Fiap2025@
```

## Como Executar Localmente

### Pré-requisitos

- .NET 8 SDK
- SQL Server rodando (via Docker — ver [AgroSolutions-Infra](https://github.com/marceloms17/AgroSolutions-Infra))

### Executar

```powershell
git clone https://github.com/lhpatrocinio/ApiProdutorRuralAutenticacao.git
cd ApiProdutorRuralAutenticacao
dotnet restore
dotnet run --project ProdutorRuralAutenticacao.Api
```

Swagger disponível em: `http://localhost:5000/swagger`

### Executar Testes

```powershell
dotnet test
```

## Configuração JWT

```json
{
  "JwtSettings": {
    "SecretKey": "AgroSolutions2026HackatonFiap8NETT!SecretKey@JWT",
    "Issuer": "AgroSolutions.Auth",
    "Audience": "AgroSolutions.APIs",
    "ExpirationMinutes": 60
  }
}
```

> ⚠️ O mesmo `SecretKey` deve estar configurado nos demais microsserviços para validação de token.

## Tecnologias

- .NET 8 / ASP.NET Core
- Entity Framework Core 8 + SQL Server
- JWT Bearer Authentication
- BCrypt.Net (hash de senhas)
- Swagger / OpenAPI
- xUnit + Moq + FluentAssertions
- GitHub Actions (CI/CD)

## Relacionamento com outros serviços

Este serviço **não consome nem publica eventos RabbitMQ**. Os demais microsserviços validam o JWT localmente usando a chave compartilhada.
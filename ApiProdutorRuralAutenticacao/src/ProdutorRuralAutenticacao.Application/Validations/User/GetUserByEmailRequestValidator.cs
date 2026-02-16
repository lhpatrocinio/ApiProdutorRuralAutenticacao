using FluentValidation;
using ProdutorRuralAutenticacao.Application.Dtos.Requests;

namespace ProdutorRuralAutenticacao.Application.Validations.User
{
    public class GetUserByEmailRequestValidator : AbstractValidator<GetUserByEmailRequest>
    {
        public GetUserByEmailRequestValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("O campo Email deve conter um endereço de e-mail válido.");
        }
    }
}

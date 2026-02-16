using FluentValidation;
using ProdutorRuralAutenticacao.Application.Dtos.Requests;

namespace ProdutorRuralAutenticacao.Application.Validations.User
{
    public class GetUserByNickNameRequestValidator : AbstractValidator<GetUserByNickNameRequest>
    {
        public GetUserByNickNameRequestValidator()
        {
            RuleFor(x => x.NickName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo NickName deve ser informado.");
        }
    }
}

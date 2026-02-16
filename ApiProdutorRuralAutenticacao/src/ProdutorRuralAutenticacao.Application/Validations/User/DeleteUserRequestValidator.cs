using FluentValidation;
using ProdutorRuralAutenticacao.Application.Dtos.Requests;

namespace ProdutorRuralAutenticacao.Application.Validations.User
{
    public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Id deve ser informado.");
        }
    }
}
using Angular.Aplicacao.DTO.Usuarios;
using FluentValidation;

namespace Angular.Aplicacao.Validators.Usuarios
{
    public class UserForRegisterDTOValidator : AbstractValidator<UserForRegisterDTO>
    {
        public UserForRegisterDTOValidator()
        {
            RuleFor(u => u.Username).NotNull().WithMessage("O campo username não pode estar nulo");
            RuleFor(u => u.Password).NotNull().WithMessage("O campo password não pode estar nulo");
            RuleFor(u => u.Password).MaximumLength(12).WithMessage("O campo password pode ter no máximo 12 caracteres");
            RuleFor(u => u.Password).MinimumLength(8).WithMessage("O campo password pode ter no mínimo 8 caracteres");
        }
    }
}

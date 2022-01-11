// Alberto Segundo Palencia Benedetty

using FluentValidation;

namespace Application.Feautures.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(it => it.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(it => it.Apellido)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(it => it.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(it => it.UserName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(it => it.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(15).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(it => it.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(15).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .Equal(p => p.Password).WithMessage("{PropertyName} debe ser igual a password");
        }
    }
}
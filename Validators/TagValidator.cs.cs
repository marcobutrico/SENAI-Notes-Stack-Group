using FluentValidation;
using SENAI_Notes.Models;


namespace SenaiNotes.Validators
{
    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(t => t.Name)
            .NotEmpty().WithMessage("O nome da tag é obrigatório.")
            .MaximumLength(50).WithMessage("O nome da tag deve ter no máximo 50 caracteres.");

            RuleFor(t => t.IdUser)
                .NotNull().WithMessage("O usuário da tag é obrigatório.");
        }
    }
}
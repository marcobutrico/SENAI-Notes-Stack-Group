using FluentValidation;
using SENAI_Notes.DTO;
using SENAI_Notes.Models;

namespace SENAI_Notes.Validators
{
    public class AnotacaoDtoValidator : AbstractValidator<CadastroAnotacaoDto>
    {
        public AnotacaoDtoValidator()
        {
            RuleFor(a => a.Title)
           .NotEmpty().WithMessage("O título da anotação é obrigatório.")
           .MaximumLength(100).WithMessage("O título da anotação deve ter no máximo 100 caracteres.");

            RuleFor(a => a.Content)
                .NotEmpty().WithMessage("A descrição da anotação é obrigatória.");

            RuleFor(a => a.DataCriacao)
                .NotEmpty().WithMessage("A data de criação é obrigatória.");

            RuleFor(a => a.ImageUrl)
                .MaximumLength(255).WithMessage("O caminho da imagem deve ter no máximo 255 caracteres.");

            RuleFor(a => a.IdUser)
                .NotNull().WithMessage("O usuário da anotação é obrigatório.");
        }
    }
}
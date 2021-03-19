using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Gerente.Dominio.Entidades;

namespace Gerente.Dominio.Validadores
{
    public class UsuarioValidador : AbstractValidator<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(" Não pode ser vazia.")

                .NotNull()
                .WithMessage(" Não pode ser Nula.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(" O nome não pode ser vazio.")

                .NotNull()
                .WithMessage(" O nome não pode ser Nulo.")

                .MinimumLength(3)
                .WithMessage(" O nome tem que ter no mínimo 3 ctrs.")

                .MaximumLength(30)
                .WithMessage(" O nome tem que ter no máximo 30 ctrs.");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(" Não pode ser vazia.")
                .NotNull()
                .WithMessage(" Não pode ser Nula.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(" O email não pode ser vazio.")

                .NotNull()
                .WithMessage(" O email não pode ser Nulo.")

                .MinimumLength(10)
                .WithMessage(" O email tem que ter no mínimo 10 ctrs.")

                .MaximumLength(180)
                .WithMessage(" O email tem que ter no máximo 180 ctrs.")

                .EmailAddress()
                .WithMessage(" Email inválido");
        }
    }
}
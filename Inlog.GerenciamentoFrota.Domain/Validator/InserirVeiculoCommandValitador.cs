using FluentValidation;
using Inlog.GerenciamentoFrota.Domain.Command;

namespace Inlog.GerenciamentoFrota.Domain.Validator
{
	public class InserirVeiculoCommandValitador : AbstractValidator<InserirVeiculoCommand>
	{
		public InserirVeiculoCommandValitador()
		{
			RuleFor(c => c.Chassi)
				.Length(17)
				.WithMessage("O Chassi do veículo deve conter exatamente 17 caracteres.");

			RuleFor(c => c.Cor)
				.NotNull()
				.NotEmpty()
				.Length(1, 150);

			RuleFor(c => c.TipoVeiculo)
				.NotEmpty();
		}
	}
}

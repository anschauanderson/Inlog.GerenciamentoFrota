using Inlog.GerenciamentoFrota.Domain.Dto;
using Inlog.GerenciamentoFrota.Domain.Enum;
using MediatR;

namespace Inlog.GerenciamentoFrota.Domain.Command
{
	public class InserirVeiculoCommand : IRequest<string>
	{
		public string Chassi { get; set; }
		public string Cor { get; set; }
		public TipoVeiculoEnum TipoVeiculo { get; set; }
	}
}

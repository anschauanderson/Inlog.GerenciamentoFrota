using Inlog.GerenciamentoFrota.Domain.Dto;
using MediatR;

namespace Inlog.GerenciamentoFrota.Domain.Command
{
	public class EditarVeiculoCommand : IRequest<string>
	{
		public string chassi { get; set; }
		public string Cor { get; set; }
	}
}

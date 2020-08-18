using MediatR;

namespace Inlog.GerenciamentoFrota.Domain.Command
{
	public class DeletarVeiculoCommand : IRequest<string>
	{
		public string Chassi { get; set; }
	}
}

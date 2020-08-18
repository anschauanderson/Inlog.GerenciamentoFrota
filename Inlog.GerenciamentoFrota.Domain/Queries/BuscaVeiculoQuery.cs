using Inlog.GerenciamentoFrota.Domain.Dto;
using MediatR;

namespace Inlog.GerenciamentoFrota.Domain.Queries
{
	public class BuscarVeiculoQuery : IRequest<VeiculoDto>
	{
		public string Chassi { get; set; }
	}
}

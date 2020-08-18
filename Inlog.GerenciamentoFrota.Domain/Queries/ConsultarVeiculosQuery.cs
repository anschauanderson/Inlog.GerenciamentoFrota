using Inlog.GerenciamentoFrota.Domain.Dto;
using MediatR;
using System.Collections.Generic;

namespace Inlog.GerenciamentoFrota.Domain.Queries
{
	public class ConsultarVeiculosQuery : IRequest<List<VeiculoDto>>
	{
	}
}

using Inlog.GerenciamentoFrota.Domain.Command;
using Inlog.GerenciamentoFrota.Domain.Dto;
using Inlog.GerenciamentoFrota.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inlog.GerenciamentoFrota.Api.Controllers
{
	public class VeiculoController : Controller
	{
		private readonly IMediator _mediator;

		public VeiculoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Inserir")]
		public async Task<string> Post([FromBody] InserirVeiculoCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpGet("BuscarPorChassi")]
		public async Task<VeiculoDto> Get([FromQuery] BuscarVeiculoQuery query)
		{
			return await _mediator.Send(query);
		}

		[HttpGet("listar")]
		public async Task<List<VeiculoDto>> Lista([FromQuery] ConsultarVeiculosQuery query)
		{
			return await _mediator.Send(query);
		}

		[HttpPut("Editar")]
		public async Task<string> Put([FromBody] EditarVeiculoCommand command)
		{
			return await _mediator.Send(command);
		}

		[HttpDelete("Deletar")]
		public async Task<string> Delete([FromBody] DeletarVeiculoCommand command)
		{
			return await _mediator.Send(command);
		}
	}
}

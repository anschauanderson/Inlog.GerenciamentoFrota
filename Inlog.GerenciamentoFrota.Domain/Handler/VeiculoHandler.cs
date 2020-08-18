using AutoMapper;
using Inlog.GerenciamentoFrota.Domain.Command;
using Inlog.GerenciamentoFrota.Domain.Dto;
using Inlog.GerenciamentoFrota.Domain.Entities;
using Inlog.GerenciamentoFrota.Domain.Queries;
using Inlog.GerenciamentoFrota.Domain.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Inlog.GerenciamentoFrota.Domain.Handler
{
	public class VeiculoHandler :
		IRequestHandler<InserirVeiculoCommand, string>,
		IRequestHandler<BuscarVeiculoQuery, VeiculoDto>,
		IRequestHandler<EditarVeiculoCommand, string>,
		IRequestHandler<ConsultarVeiculosQuery, List<VeiculoDto>>,
		IRequestHandler<DeletarVeiculoCommand, string>
	{
		private readonly IVeiculoRepository _repository;
		private readonly IMapper _mapper;
		public VeiculoHandler(IVeiculoRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public Task<string> Handle(InserirVeiculoCommand request, CancellationToken cancellationToken)
		{
			Veiculo veiculoInserir = null;
			switch (request.TipoVeiculo)
			{
				case Enum.TipoVeiculoEnum.Caminhao:
					veiculoInserir = _mapper.Map<Caminhao>(request);
					break;
				case Enum.TipoVeiculoEnum.Onibus:
					veiculoInserir = _mapper.Map<Onibus>(request);
					break;
				default:
					break;
			}			
			return Task.FromResult(_repository.InserirVeiculo(veiculoInserir));
		}

		public Task<VeiculoDto> Handle(BuscarVeiculoQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repository.BuscarVeiculoPorChassi(request.Chassi));
		}

		public Task<string> Handle(EditarVeiculoCommand request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repository.EditarVeiculo(request.chassi, request.Cor));
		}

		public Task<List<VeiculoDto>> Handle(ConsultarVeiculosQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repository.BuscarTodosVeiculos());
		}

		public Task<string> Handle(DeletarVeiculoCommand request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_repository.DeletarVeiculo(request.Chassi));
		}
	}
}

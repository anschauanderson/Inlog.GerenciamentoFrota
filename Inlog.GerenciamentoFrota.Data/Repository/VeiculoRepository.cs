using Inlog.GerenciamentoFrota.Domain.Dto;
using Inlog.GerenciamentoFrota.Domain.Entities;
using Inlog.GerenciamentoFrota.Domain.Repository;
using System.Collections.Generic;
using Inlog.GerenciamentoFrota.Data.DataContext;
using System.Linq;
using AutoMapper;

namespace Inlog.GerenciamentoFrota.Data.Repository
{
	public class VeiculoRepository : IVeiculoRepository
	{
		private static VeiculoDataContext _dbContext;
		private static IMapper _mapper;
		public VeiculoRepository(VeiculoDataContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public List<VeiculoDto> BuscarTodosVeiculos()
		{
			return _dbContext.Veiculos.Select(c => _mapper.Map<VeiculoDto>(c)).ToList();
		}

		public VeiculoDto BuscarVeiculoPorChassi(string chassi)
		{
			return _dbContext.Veiculos
				.Where(c => c.Chassi == chassi)
				.Select(c => _mapper.Map<VeiculoDto>(c))
				.FirstOrDefault();
		}

		public string DeletarVeiculo(string chassi)
		{
			var veiculo = _dbContext.Veiculos.FirstOrDefault(c => c.Chassi == chassi);

			if (veiculo == null)
				return "O chassi informado não pertence a um veículo";

			_dbContext.Remove(veiculo);
			_dbContext.SaveChanges();

			return "Veículo deletado com sucesso!";
		}

		public string EditarVeiculo(string chassi, string cor)
		{
			var veiculo = _dbContext.Veiculos.FirstOrDefault(c => c.Chassi == chassi);
			if (veiculo == null)
				return "O chassi informado não pertence a um veículo";

			veiculo.Cor = cor;
			_dbContext.SaveChanges();
			return "Veículo editado com sucesso!";
		}

		public string InserirVeiculo(Veiculo veiculo)
		{
			var veiculoDb = _dbContext.Veiculos.FirstOrDefault(c => c.Chassi == veiculo.Chassi);
			if (veiculoDb != null)
			{
				return "Este chassi já está cadastrado";
			}

			veiculoDb = _mapper.Map<Model.Veiculo>(veiculo);
			_dbContext.Veiculos.Add(veiculoDb);
			_dbContext.SaveChanges();
			return "Veículo inserido com sucesso!";
		}
	}
}

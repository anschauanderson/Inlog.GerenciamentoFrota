using Inlog.GerenciamentoFrota.Domain.Dto;
using Inlog.GerenciamentoFrota.Domain.Entities;
using System.Collections.Generic;

namespace Inlog.GerenciamentoFrota.Domain.Repository
{
	public interface IVeiculoRepository
	{
		string InserirVeiculo(Veiculo veiculo);
		string EditarVeiculo(string chassi, string cor);
		string DeletarVeiculo(string chassi);
		List<VeiculoDto> BuscarTodosVeiculos();
		VeiculoDto BuscarVeiculoPorChassi(string chassi);
	}
}

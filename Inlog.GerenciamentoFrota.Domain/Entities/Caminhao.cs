using Inlog.GerenciamentoFrota.Domain.Enum;

namespace Inlog.GerenciamentoFrota.Domain.Entities
{
	public class Caminhao : Veiculo
	{
		public override int QtPassageiros => 2;

		public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Caminhao;
	}
}

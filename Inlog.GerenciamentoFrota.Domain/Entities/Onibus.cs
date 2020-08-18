using Inlog.GerenciamentoFrota.Domain.Enum;

namespace Inlog.GerenciamentoFrota.Domain.Entities
{
	public class Onibus : Veiculo
	{
		public override int QtPassageiros => 42;

		public override TipoVeiculoEnum TipoVeiculo => TipoVeiculoEnum.Onibus;
	}
}

using Inlog.GerenciamentoFrota.Domain.Enum;

namespace Inlog.GerenciamentoFrota.Domain.Entities
{
	public abstract class Veiculo
	{
		public string Chassi { get; set; }
		public string Cor { get; set; }
		public abstract int QtPassageiros { get; }
		public abstract TipoVeiculoEnum TipoVeiculo { get; }
	}
}

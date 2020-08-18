using Inlog.GerenciamentoFrota.Domain.Enum;

namespace Inlog.GerenciamentoFrota.Data.Model
{
	public class Veiculo
	{
		public long Id { get; set; }
		public string Chassi { get; set; }
		public string Cor { get; set; }
		public int QtPassageiros { get; set; }
		public TipoVeiculoEnum TipoVeiculoId { get; set; }
	}
}

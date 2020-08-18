using Inlog.GerenciamentoFrota.Domain.Enum;

namespace Inlog.GerenciamentoFrota.Domain.Dto
{
	public class VeiculoDto
	{
		public long Id { get; set; }
		public string Chassi { get; set; }
		public string Cor { get; set; }
		public int QtPassageiros { get; set; }
		public TipoVeiculoEnum TipoVeiculo { get; set; }
	}
}

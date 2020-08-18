using Inlog.GerenciamentoFrota.Domain.Command;
using Inlog.GerenciamentoFrota.Domain.Handler;
using Inlog.GerenciamentoFrota.Domain.Repository;
using Moq;
using System.Threading;
using Xunit;

namespace Inlog.GerenciamentoFrota.Test.Handler
{
	public class VeiculoHandlerTest : CadastroTesteBase
	{
		[Fact(DisplayName = "Testar Insersão de Veículo")]
		public void TestarInserirVeiculo()
		{
			InserirVeiculoCommand command = new InserirVeiculoCommand()
			{
				Chassi = "NOVOCHASSI123456",
				Cor = "PRETA",
				TipoVeiculo = Domain.Enum.TipoVeiculoEnum.Caminhao
			};
			var rep = new Mock<IVeiculoRepository>();
			rep.SetReturnsDefault("Veiculo cadastrado com sucesso!");

			VeiculoHandler handler = new VeiculoHandler(rep.Object, Mapper);
			var response = handler.Handle(command, CancellationToken.None);

			Assert.True(response.Result == "Veiculo cadastrado com sucesso!");
		}
	}
}

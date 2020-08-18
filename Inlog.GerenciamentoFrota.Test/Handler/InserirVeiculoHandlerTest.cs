using Inlog.GerenciamentoFrota.Data.DataContext;
using Inlog.GerenciamentoFrota.Domain.Command;
using Inlog.GerenciamentoFrota.Domain.Handler;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace Inlog.GerenciamentoFrota.Test.Handler
{
	public class InserirVeiculoHandlerTest : CadastroTesteBase
	{
		[Fact(DisplayName = "Testar Insersão de Veículo")]
		public void TestarInserirVeiculo()
		{
			VeiculoDataContext dbContext = CriarDataContext();
			
			InserirVeiculoCommand command = new InserirVeiculoCommand()
			{
				Chassi = "NOVOCHASSI123456",
				Cor = "PRETA",
				TipoVeiculo = Domain.Enum.TipoVeiculoEnum.Caminhao
			};
			var repository = CriaVeiculoRepository(Mapper.Map<Domain.Entities.Caminhao>(command));

			VeiculoHandler handler = new VeiculoHandler(repository, Mapper);
			var response = handler.Handle(command, CancellationToken.None);

			dbContext.Database.EnsureDeleted();

			Assert.True(response.Result == "Veiculo cadastrado com sucesso!");
		}
	}
}

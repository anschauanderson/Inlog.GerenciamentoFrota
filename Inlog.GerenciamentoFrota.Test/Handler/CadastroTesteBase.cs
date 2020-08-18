using AutoMapper;
using Inlog.GerenciamentoFrota.Api.Mapper;
using Inlog.GerenciamentoFrota.Data.DataContext;
using Inlog.GerenciamentoFrota.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Inlog.GerenciamentoFrota.Test.Handler
{
	public class CadastroTesteBase
	{
		protected static IMapper Mapper { get; set; }

		public CadastroTesteBase()
		{
			Mapper = CriarAutoMapper();
		}

		protected VeiculoDataContext CriarDataContext()
		{
			var options = new DbContextOptionsBuilder<VeiculoDataContext>()
		   .UseInMemoryDatabase(databaseName: "GerenciaFrota")
		   .Options;
			return new VeiculoDataContext(options);
		}

		private IMapper CriarAutoMapper()
		{
			//auto mapper configuration
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new VeiculoProfile());
			});
			return mockMapper.CreateMapper();
		}
		protected IVeiculoRepository CriaVeiculoRepository(Domain.Entities.Veiculo veiculo)
		{
			var rep = new Mock<IVeiculoRepository>();
			rep.Setup(c => c.InserirVeiculo(veiculo)).Returns("Veiculo cadastrado com sucesso!");
			return rep.Object;
		}
	}
}

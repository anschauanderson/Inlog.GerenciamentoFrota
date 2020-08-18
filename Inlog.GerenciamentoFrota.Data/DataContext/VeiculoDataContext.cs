using Microsoft.EntityFrameworkCore;
using Inlog.GerenciamentoFrota.Data.Model;

namespace Inlog.GerenciamentoFrota.Data.DataContext
{
	public class VeiculoDataContext : DbContext
	{
		public VeiculoDataContext(DbContextOptions<VeiculoDataContext> options) : base(options)
		{
		}

		public DbSet<Veiculo> Veiculos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Veiculo>().ToTable("Veiculo");			
		}
	}
}

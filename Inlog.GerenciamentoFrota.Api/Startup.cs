using AutoMapper;
using FluentValidation.AspNetCore;
using Inlog.GerenciamentoFrota.Api.Mapper;
using Inlog.GerenciamentoFrota.Data.DataContext;
using Inlog.GerenciamentoFrota.Data.Repository;
using Inlog.GerenciamentoFrota.Domain.Handler;
using Inlog.GerenciamentoFrota.Domain.Repository;
using Inlog.GerenciamentoFrota.Domain.Validator;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Inlog.GerenciamentoFrota.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddFluentValidation(opt => {
					opt.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(InserirVeiculoCommandValitador)));
				});
			
			services.AddDbContext<VeiculoDataContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddMediatR(typeof(VeiculoHandler));

			services.AddScoped<IVeiculoRepository, VeiculoRepository>();

			ConfigureSwagger(services, "Inlog Gerenciamento de Frota API");

			services.AddAutoMapper(typeof(VeiculoProfile));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			BuildSwagger(app, "Inlog Gerenciamento de Frota API");

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
		public static void ConfigureSwagger(IServiceCollection services, string description = "", string version = "v1")
		{
			services.AddSwaggerGen(c =>
			{
				c.UseInlineDefinitionsForEnums();
				c.SwaggerDoc("v1", new OpenApiInfo { Title = description, Version = version ?? "v1" });;
			});
		}

		public static void BuildSwagger(IApplicationBuilder app, string name = "")
		{
			name = string.IsNullOrEmpty(name) ? $"{Assembly.GetEntryAssembly()?.GetName().Name}" : name;

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", name);
				c.RoutePrefix = string.Empty;
			});
		}
	}
}

using AutoMapper;
using Inlog.GerenciamentoFrota.Domain.Command;
using Inlog.GerenciamentoFrota.Domain.Dto;
using Inlog.GerenciamentoFrota.Domain.Entities;
using Inlog.GerenciamentoFrota.Domain.Enum;

namespace Inlog.GerenciamentoFrota.Api.Mapper
{
	public class VeiculoProfile : Profile
	{
		public VeiculoProfile()
		{
			CreateMap<Veiculo, VeiculoDto>().ReverseMap();
			
			CreateMap<InserirVeiculoCommand, Caminhao>().ReverseMap();

			CreateMap<InserirVeiculoCommand, Onibus>().ReverseMap();

			CreateMap<Veiculo, InserirVeiculoCommand>().ReverseMap();

			CreateMap<Data.Model.Veiculo, Veiculo>()
				.ForMember(c => c.TipoVeiculo, opt => opt.MapFrom(src => src.TipoVeiculoId)).ReverseMap();

			CreateMap<Data.Model.Veiculo, VeiculoDto>()				 
				.ForMember(c => c.TipoVeiculo, opt => opt.MapFrom(src => src.TipoVeiculoId)).ReverseMap();

		}
	}
}

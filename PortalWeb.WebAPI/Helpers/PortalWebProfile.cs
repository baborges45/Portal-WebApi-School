using AutoMapper;
using PortalWeb.WebAPI.Dtos;
using PortalWeb.WebAPI.Models;

namespace PortalWeb.WebAPI.Helpers
{
  public class PortalWebProfile : Profile
  {
    public PortalWebProfile()
    {
      CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );

      CreateMap<AlunoDto, Aluno>();
      CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

      CreateMap<Professor, ProfessorDto>()
                       .ForMember(
                           dest => dest.Nome,
                           opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                           );

      CreateMap<ProfessorDto, Professor>();
      CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
    }
  }
}
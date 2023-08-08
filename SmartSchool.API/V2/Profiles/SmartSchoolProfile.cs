using AutoMapper;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.API.V2.Dtos;

namespace SmartSchool.API.V2.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(
                        src => $"{src.Nome} {src.Sobrenome}"))
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(
                        src => src.DataNasc.GetCurrentAge())
                    );

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

        }
    }
}

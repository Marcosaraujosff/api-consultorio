using api_consultorio.Models.Dtos;
using AutoMapper;
using Consultorio.Models.Entities;

namespace api_consultorio.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteDetalhesDto>()
            .ForMember(dest => dest.Email, options => options.Ignore());

            CreateMap<Consulta, ConsultaDto>()
            .ForMember(dest => dest.Especialidade, options => options.MapFrom(src => src.Especialidade.Nome))
            .ForMember(dest => dest.Profissional, options => options.MapFrom(src => src.Profissional.Nome));

            CreateMap<PacienteAdicionarDto, Paciente>();
            CreateMap<PacienteAtualizarDto, Paciente>()
                .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.Consultas, options => options.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.Especialidades, options => options.MapFrom(src => src.Especialidades
                .Select(x => x.Nome).ToArray()));

            CreateMap<ProfissionalDetalhesDto, Profissional>();

            CreateMap<ProfissionalAdicionarAtualizarDto, Profissional>();
            CreateMap<ProfissionalAdicionarAtualizarDto, Profissional>()
                .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Especialidade, EspecialidadeDetalhesDto>();
        }
    }
}

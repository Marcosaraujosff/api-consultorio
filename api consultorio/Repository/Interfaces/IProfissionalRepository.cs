using api_consultorio.Models.Dtos;
using Consultorio.Models.Entities;

namespace api_consultorio.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> BuscarProfissionais();
        Task<Profissional> BuscarProfissionaisPorId(int id);
        Task<ProfissionalEspecialidade> BuscarProfissionalEspecialidade(int profissionalId, int especialidadeId);
    }
}

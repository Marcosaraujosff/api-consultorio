using api_consultorio.Models.Dtos;
using Consultorio.Models.Entities;

namespace api_consultorio.Repository.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<EspecialidadeDto>> BuscarEspecialidades();
        Task<Especialidade> BuscarEspecialidadesPorId(int id);
    }
}

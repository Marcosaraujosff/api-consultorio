using api_consultorio.Models.Dtos;
using Consultorio.Models.Entities;

namespace api_consultorio.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<PacienteDto>> GetPacientesAsync();
        Task<Paciente> GetByIdAsync(int id);
    }
}

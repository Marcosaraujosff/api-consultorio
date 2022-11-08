using api_consultorio.context;
using api_consultorio.Models.Dtos;
using api_consultorio.Repository.Interfaces;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_consultorio.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {

        private readonly DataContext _context;

        public PacienteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PacienteDto>> GetPacientesAsync()
        {
            return  await _context.Pacientes.Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome }).ToListAsync();

           
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _context.Pacientes.Include(x => x.Consultas).ThenInclude(x => x.Especialidade).ThenInclude(x => x.Profissionais).Where(x => x.Id == id).FirstOrDefaultAsync();

            
        }

    }
}

using api_consultorio.context;
using api_consultorio.Models.Dtos;
using api_consultorio.Repository.Interfaces;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_consultorio.Repository
{
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        private readonly DataContext _context;

        public EspecialidadeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EspecialidadeDto>> BuscarEspecialidades()
        {
            return await _context.Especialidades.Select(x => new EspecialidadeDto { Id = x.Id, Nome = x.Nome, Ativa = x.Ativa }).ToListAsync();
        }

        public async Task<Especialidade> BuscarEspecialidadesPorId(int id)
        {
            return await _context.Especialidades.Include(x => x.Profissionais).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}

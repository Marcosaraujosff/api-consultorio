using api_consultorio.context;
using api_consultorio.Models.Dtos;
using api_consultorio.Repository.Interfaces;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_consultorio.Repository
{
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly DataContext _context;

        public ProfissionalRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfissionalDto>> BuscarProfissionais()
        {
            return await _context.Profissionais
                .Select(x => new ProfissionalDto { Id = x.Id, Nome = x.Nome, Ativo = x.Ativo }).ToListAsync();
        }

        public async Task<Profissional> BuscarProfissionaisPorId(int id)
        {
            return await _context.Profissionais
                .Include(x => x.Consultas)
                .Include(x => x.Especialidades)
                .Where(x => x.Id == id).FirstOrDefaultAsync(); 
        }

        public async Task<ProfissionalEspecialidade> BuscarProfissionalEspecialidade(int profissionalId, int especialidadeId)
        {
            return await _context.ProfissionaisEspecialidades.Where(x => x.ProfissionalId == profissionalId && x.EspecialidadeId == especialidadeId).FirstOrDefaultAsync();
        }

    }
}

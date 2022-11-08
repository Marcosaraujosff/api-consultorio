using api_consultorio.Models.Dtos;
using api_consultorio.Repository.Interfaces;
using AutoMapper;
using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api_consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarProfissionais()
        {
            var profissionais = await _repository.BuscarProfissionais();

            return profissionais.Any()
                ? Ok(profissionais)
                : NotFound("Pacientes não encontrados.");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProfissionaisPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Profissional invalido.");
            }

            var profissionais = await _repository.BuscarProfissionaisPorId(id);

            var profissionalRetorno = _mapper.Map<ProfissionalDetalhesDto>(profissionais);

            return profissionalRetorno != null
                ? Ok(profissionalRetorno)
                : NotFound("Profissional não encontrado.");

        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProfissional(ProfissionalAdicionarAtualizarDto profissional)
        {
            if (string.IsNullOrEmpty(profissional.Nome))
            {
                return BadRequest("Ops, faltam dados");
            }

            var profissionalAdicionar = _mapper.Map<Profissional>(profissional);

            _repository.Add(profissionalAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional adicionado.")
                : BadRequest("Erro ao adicionar o profissional.");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProfissional(int id, ProfissionalAdicionarAtualizarDto profissional)
        {
            if (id <= 0)
            {
                return BadRequest("Profissional invalido.");
            }

            var profissionalBase = await _repository.BuscarProfissionaisPorId(id);

            if (profissionalBase == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            var profissionalAtualizar = _mapper.Map(profissional, profissionalBase);

            _repository.Update(profissionalAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional atualizado.")
                : BadRequest("Erro ao atualizar o profissional.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProfissional(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Profissional invalido.");
            }

            var profissionalBase = await _repository.BuscarProfissionaisPorId(id);

            if (profissionalBase == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            _repository.Delete(profissionalBase);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional deletado.")
                : BadRequest("Erro ao deletar o profissional.");
        }

        [HttpPost("adicionar-profissional")]
        public async Task<IActionResult> CadastrarProfissionalEspecialidade(ProfissionalEspecialidadeAdicionarDto profissional)
        {
            int profissionalId = profissional.ProfissionalId;
            int especialidadeId = profissional.EspecialidadeId;

            if (profissionalId <= 0 || especialidadeId <= 0)
            {
                return BadRequest("Dados invalidos");
            }

            var profissionalEspecialidade = await _repository.BuscarProfissionalEspecialidade(profissionalId, especialidadeId);

            if (profissionalEspecialidade != null)
            {
                return Ok("Especialidade ja cadastrada");
            }

            var especialidadeAdicionar = new ProfissionalEspecialidade
            {
                EspecialidadeId = especialidadeId,
                ProfissionalId = profissionalId,
            };

            _repository.Add(especialidadeAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialidade salva com sucesso.")
                : BadRequest("Erro ao adicionar a especialidade.");
        }

        [HttpDelete("{profissionalId}/deletar-especialidade/{especialidadeId}")]
        public async Task<ActionResult> DeletarEspecialidade(int profissionalId, int especialidadeId)
        {
            if (profissionalId <= 0 || especialidadeId <= 0)
            {
                return BadRequest("Dados invalidos");
            }

            var profissionalEspecialidade = await _repository.BuscarProfissionalEspecialidade(profissionalId, especialidadeId);

            if (profissionalEspecialidade == null)
            {
                return Ok("Especialidade não cadastrada");
            }

            _repository.Delete(profissionalEspecialidade);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialidade deletada com sucesso.")
                : BadRequest("Erro ao deletar a especialidade.");

        }
    }
}

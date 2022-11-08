using api_consultorio.Models.Dtos;
using api_consultorio.Repository.Interfaces;
using AutoMapper;
using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api_consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : Controller

    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _repository.GetPacientesAsync();

            return pacientes.Any()
                ? Ok(pacientes)
                : BadRequest("Paciente não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var paciente = await _repository.GetByIdAsync(id);

            var pacienteRetorno = _mapper.Map<PacienteDetalhesDto>(paciente);

            return pacienteRetorno != null
                ? Ok(pacienteRetorno)
                : BadRequest("Paciente não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> CadastratPaciente(PacienteAdicionarDto paciente)
        {
            if (paciente == null) return BadRequest("Dados invalidos.");

            var pacienteAdicionar = _mapper.Map<Paciente>(paciente);

            _repository.Add(pacienteAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente adicionado com sucesso.")
                : BadRequest("Erro ao adicionar o paciente.");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPaciente(int id, PacienteAtualizarDto paciente)
        {
            if (id <= 0) return BadRequest("Usuario não informado.");

            var pacienteBanco = await _repository.GetByIdAsync(id);

            var pacienteAtualizar = _mapper.Map(paciente, pacienteBanco);

            _repository.Update(pacienteAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente atualizado com sucesso.")
                : BadRequest("Erro ao atualizar o paciente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            if (id <= 0) return BadRequest("Paciente não encontrado.");

            var pacienteExcluir = await _repository.GetByIdAsync(id);

            if(pacienteExcluir == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            _repository.Delete(pacienteExcluir);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente deletado com sucesso.")
                : BadRequest("Erro ao deletar o paciente.");
        }

    }
}

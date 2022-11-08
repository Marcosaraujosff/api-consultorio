using api_consultorio.context;
using api_consultorio.Models.Dtos;
using api_consultorio.Repository.Interfaces;
using AutoMapper;
using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api_consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarEspecialidades()
        {
            var especialidades = await _repository.BuscarEspecialidades();

            return especialidades.Any()
                ? Ok(especialidades)
                : BadRequest("Espcialidades não encontradas.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarEspecialidadePorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Dados de entrada invalidos.");
            }

            var especialidade = await _repository.BuscarEspecialidadesPorId(id);

            var especialidadeRetorno = _mapper.Map<EspecialidadeDetalhesDto>(especialidade);

            return especialidadeRetorno != null
                ? Ok(especialidadeRetorno)
                : BadRequest("Especialidade não encontradas.");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEspecialidade(EspecialidadeAdicionarDto especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Nome))
            {
                return BadRequest("Ops, faltam dados.");
            }

            var especialidadeAdicionar = new Especialidade
            {
                Nome = especialidade.Nome,
                Ativa = especialidade.Ativa
            };

            _repository.Add(especialidadeAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Salvo com sucesso.")
                : BadRequest("Falha ao salvar os dados.");

        }

        [HttpPut("{îd}/atualizar-status/")]
        public async Task<IActionResult> AtualizarStatusEspecialidade(int id, bool ativo)
        {
            if (id <= 0)
            {
                return BadRequest("Dados de entrada invalidos.");
            }

            var especialidade = await _repository.BuscarEspecialidadesPorId(id);

            if (especialidade == null)
            {
                return NotFound("Especialidade não existe.");
            }

            var status = ativo ? "ativa" : "inativa";

            if(especialidade.Ativa == ativo)
            {
                return Ok("A especialidade ja esta " + status);
            }

            especialidade.Ativa = ativo;

            _repository.Update(especialidade);

            return await _repository.SaveChangesAsync()
                ? Ok("Salvo com sucesso.")
                : BadRequest("Falha ao salvar os dados.");

        }
    }
}

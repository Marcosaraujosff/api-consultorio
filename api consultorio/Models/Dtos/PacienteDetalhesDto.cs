using Consultorio.Models.Entities;

namespace api_consultorio.Models.Dtos
{
    public class PacienteDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public List<ConsultaDto> Consultas { get; set; }
    }
}

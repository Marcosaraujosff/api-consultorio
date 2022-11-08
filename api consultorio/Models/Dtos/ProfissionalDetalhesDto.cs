using Consultorio.Models.Entities;

namespace api_consultorio.Models.Dtos
{
    public class ProfissionalDetalhesDto
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int Consultas { get; set; }
        public string[] Especialidades { get; set; }
    }
}

using Consultorio.Models.Entities;

namespace api_consultorio.Models.Dtos
{
    public class EspecialidadeDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public List<ProfissionalDto> Profissionais { get; set; }
    }
}

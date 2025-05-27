namespace SENAI_Notes.DTO
{
    public class CadastroAnotacaoDto
    {

        public string? Title { get; set; } = null!;

        public string? Content { get; set; } = null!;

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataEdicao { get; set; }

        public string? ImageUrl { get; set; } = null!;

        public bool? IsArchived { get; set; }

        public int IdUser { get; set; }

        public IFormFile? ArquivoImagem { get; set; }

        public List<string> Tags { get; set; }
    }
}
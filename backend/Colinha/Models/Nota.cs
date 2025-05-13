namespace OrganizedNotesAPI.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Prioridade { get; set; } // Alta, Media, Baixa
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Tag> Tags { get; set; }
    }
}

namespace OrganizedNotesAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Nota> Notas { get; set; }
    }
}

namespace SENAI_Notes.DTO
{
    public class Notas
    {
        public int IdNote { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int IdUser { get; set; }

        public List<string> tags { get; set; }
    }

    public class NoteRequestDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

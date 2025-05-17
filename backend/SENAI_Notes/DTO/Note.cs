namespace SENAI_Notes.DTO
{
    public class Note
    {
        public int IdNote { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsFavorite { get; set; }
        public bool? IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IdUser { get; set; }
    }
}

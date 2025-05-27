using SENAI_Notes.Models;
using SENAI_Notes.ViewModels;

namespace SENAI_Notes.ViewModels
{
    public class ListarAnotacaoViewModel
    {
        public int IdNote { get; set; }


        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public string? ImageUrl { get; set; } 

        public bool? IsFavorite { get; set; }

        public bool IsArchived { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<ListarTagViewModel> Tags { get; set; } 
    }
}


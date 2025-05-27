using System;
using System.Collections.Generic;

namespace SENAI_Notes.Models;

public partial class NotesUser
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? UserThemePreferences { get; set; }

    public int? UserFontPreferences { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}

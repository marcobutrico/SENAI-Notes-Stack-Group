﻿using System;
using System.Collections.Generic;

namespace SENAI_Notes.Models;

public partial class Tag
{
    public int IdTag { get; set; }

    public string? Name { get; set; }

    public int? IdUser { get; set; }

    public virtual NotesUser? IdUserNavigation { get; set; }

    public virtual ICollection<Notetag> Notetags { get; set; } = new List<Notetag>();
}

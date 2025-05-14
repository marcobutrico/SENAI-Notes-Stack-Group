using System;
using System.Collections.Generic;

namespace SENAI_Notes.Models;

public partial class Notetag
{
    public int IdNoteTag { get; set; }

    public int? IdNote { get; set; }

    public int? IdTag { get; set; }

    public virtual Note? IdNoteNavigation { get; set; }

    public virtual Tag? IdTagNavigation { get; set; }
}


namespace SENAI_Notes.Repositories
{
    internal class SENAI_NotesContext
    {
        public object Notetag { get; internal set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
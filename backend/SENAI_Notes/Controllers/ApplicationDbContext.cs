

namespace SENAI_Notes.Controllers
{
    internal class ApplicationDbContext
    {
        public IEnumerable<object> Note { get; internal set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
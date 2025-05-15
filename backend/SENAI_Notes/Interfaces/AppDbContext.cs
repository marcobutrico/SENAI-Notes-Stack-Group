
using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Models;

namespace SENAI_Notes.Interfaces
{
    internal class AppDbContext
    {
        private DbSet<Tag> tags;

        public object Tag { get; internal set; }
        public object Tags { get; internal set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
      
    }
}
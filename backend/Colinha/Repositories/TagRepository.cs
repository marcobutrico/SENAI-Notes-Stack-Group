using OrganizedNotesAPI.Models;
using OrganizedNotesAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OrganizedNotesAPI.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DbContext _context;
        public TagRepository(DbContext context) => _context = context;

        public async Task<List<Tag>> GetAllAsync() => await _context.Set<Tag>().ToListAsync();
        public async Task<Tag> GetByIdAsync(int id) => await _context.Set<Tag>().FindAsync(id);
        public async Task AddAsync(Tag tag)
        {
            await _context.Set<Tag>().AddAsync(tag);
            await _context.SaveChangesAsync();
        }
    }
}

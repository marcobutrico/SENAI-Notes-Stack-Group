using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;

namespace SENAI_Notes.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {

        public TagRepository(SenaiNotesContext context) : base(context)
        {

        }

        public List<Tag> BuscarPorUsuario(int id)
        {
            var tags = _context.Tags.Where(t => t.IdUser == id).ToList();

            return tags;
        }

        public Tag BuscarPorUsuarioeId(int id, string nome)
        {
            var tags = _context.Tags.FirstOrDefault(t => t.IdUser == id && t.Name == nome);

            return tags;
        }
    }
}
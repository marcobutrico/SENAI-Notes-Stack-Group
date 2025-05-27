using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.DTO;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using SENAI_Notes.ViewModels;


namespace SENAI_Notes.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        private TagRepository tagRepository;
        public NoteRepository(SenaiNotesContext context) : base(context)
        {
            tagRepository = new TagRepository(context);
        }

        public Note? ArquivarAnotacao(int id)
        {
            var anotacao = _context.Notes.Find(id);

            if (anotacao == null) return null;

            anotacao.IsArchived = !anotacao.IsArchived;

            _context.SaveChanges();

            return anotacao;
        }

        public List<Note> BuscarPorUsuario(int id)
        {
            var anotacoes = _context.Notes.Where(a => a.IdUser == id).ToList();

            return anotacoes;
        }

        public CadastroAnotacaoDto? CadastrarAnotacao(CadastroAnotacaoDto anotacao)
        {
            List<int> idTags = new List<int>();

            foreach (var item in anotacao.Tags)
            {
                var tag = tagRepository.BuscarPorUsuarioeId(anotacao.IdUser, item);

                if (tag == null)
                {

                    tag = new Tag
                    {
                        Name = item,
                        IdUser = anotacao.IdUser
                    };

                    _context.Add(tag);
                    _context.SaveChanges();
                }

                idTags.Add(tag.IdTag);
            }

            var novaAnotacao = new Note
            {
                Title = anotacao.Title,
                Content = anotacao.Content,
                ImageUrl = anotacao.ImageUrl,
                IsArchived = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IdUser = anotacao.IdUser
            };

            _context.Add(novaAnotacao);
            _context.SaveChanges();

            foreach (var item in idTags)
            {
                var tagAnotacao = new Notetag
                {
                    IdNote = novaAnotacao.IdNote,
                    IdTag = item
                };

                _context.Add(tagAnotacao);
                _context.SaveChanges();
            }

            return anotacao;
        }

        public List<ListarAnotacaoViewModel> ListarTodosInclude()
        {
            {
                var anotacoes = _context.Notes.Include(a => a.Notetags).ThenInclude(t => t.IdTagNavigation)
                    .Select(a => new ListarAnotacaoViewModel
                    {
                        IdNote = a.IdNote,
                        Title = a.Title,
                        Content = a.Content,
                        CreatedAt = a.CreatedAt,
                        UpdatedAt = (DateTime)(a.UpdatedAt),
                        ImageUrl = a.ImageUrl,
                        IsArchived = a.IsArchived,
                        Tags = a.Notetags.Select(t => new ListarTagViewModel
                        {
                            IdTag = t.IdTagNavigation.IdTag,
                            Name = t.IdTagNavigation.Name
                        }).ToList()
                    })
                    .ToList();

                return anotacoes;
            }
        }
    }
}
    
    
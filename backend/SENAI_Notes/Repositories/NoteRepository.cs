using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Models;
using SENAI_Notes.DTO;
using SENAI_Notes.ViewModels;

namespace SENAI_Notes.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly SenaiNotesContext _context;
        private object _TagRepository;

        public NoteRepository(SenaiNotesContext context)
        {
            _context = context;
        }
        public async Task<List<Note>> GetAllAsync(int IdUser, int titleNote, List<Note> note)
        {
            var Note = _context.Notes.Include(a => a.Notetags).ThenInclude(t => t.IdTagNavigation)
                 .ToList();

            return note;
        }

        public List<ListTagViewModel> ListAllNotes()
        {
            return new ListTagViewModel
            {
                TitleNote = a.TitleNote,
                ContentNote = a.ContentNote,
                CreatedAt = a.CreatedAt,
                DataEdicao = (DateTime)(a.UpdatedAt),
                TitleNote = a.IsArchived,
                TitleNote = a.TagNotes.Select(static t => new ListTagViewModel
                {
                    IdTag = t.IdTagNavigation.IdTag,
                    NomeTag = t.IdTagNavigation.NomeTag
                }).ToList()
            };
        }

        public Task<List<Note>> GetAllAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CadastroNoteDTO? CadastroNoteDTO(Cadastro note, Note )
        {
            List<int> idTags = new List<int>();

            foreach (var item in Note.Tag)
            {
                var tag = _tagRepository.BuscarPorUsuarioeId(Note.IdUsuario, item);

                if (tag == null)
                {

                    tag = new Tag
                    {
                        NomeTag = item,
                        IdUsuario = Note.IdUsuario
                    };

                    _context.Add(tag);
                    _context.SaveChanges();
                }

                idTags.Add(tag.IdTag);
            }

            var novaNote = new Note
            {
                TitleNote = Note.TitleNote,
                DescricaoNote = Note.DescricaoNote,
                ImagemNote = Note.ImagemNote,
                AnotacaoArquivada = false,
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                IdUsuario = Note.IdUsuario
            };

            _context.Add(novaNote);
            _context.SaveChanges();

            foreach (var item in idTags)
            {
                var tagNote = new TagNote
                {
                    IdAnotacao = novaNote.IdNote,
                    IdTag = item
                };

                _context.Add(tagNote);
                _context.SaveChanges();
            }

            return note;
        }

        public CadastroNoteDto? CadastrarAnotacao(CadastroNoteDto anotacao)
        {
            throw new NotImplementedException();
        }
    }
}

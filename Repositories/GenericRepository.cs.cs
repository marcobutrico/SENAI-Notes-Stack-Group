using Microsoft.EntityFrameworkCore;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;

namespace SENAI_Notes.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SenaiNotesContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(SenaiNotesContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T? ObterPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> ListarTodos()
        {
            return _dbSet.ToList();
        }

        public void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public T? Atualizar(int id, T entidade)
        {
            var existente = _dbSet.Find(id);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(entidade);
            _context.SaveChanges();
            return existente;
        }

        public T? Deletar(int id)
        {
            var entidade = _dbSet.Find(id);
            if (entidade == null) return null;

            _dbSet.Remove(entidade);
            _context.SaveChanges();
            return entidade;
        }
    }

}
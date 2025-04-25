using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Cadastrar(T entity)
        {
            entity.DataCriacao = DateTime.Now;
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _dbSet.Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public T ObterPorId(int id)
            => _dbSet.FirstOrDefault(e => e.Id == id);

        public IList<T> ObterTodos()
            => _dbSet.ToList();
    }
}

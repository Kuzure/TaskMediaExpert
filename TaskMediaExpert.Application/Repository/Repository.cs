using TaskMediaExpert.Application.Interface;
using TaskMediaExpert.Domain.Entity;

namespace TaskMediaExpert.Application.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private List<TEntity> _entities = new List<TEntity>();

        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            _entities.Add(entity);
            return Task.FromResult(entity);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_entities.AsEnumerable());
        }

        public virtual Task<IEnumerable<TEntity>> GetPageable(int page, int itemsPerPage)
        {
            return Task.FromResult(_entities.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).AsEnumerable());
        }
    }
}

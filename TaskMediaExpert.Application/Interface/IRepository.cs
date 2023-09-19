using TaskMediaExpert.Domain.Entity;

namespace TaskMediaExpert.Application.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetPageable(int page, int itemsPerPage);
    }
}

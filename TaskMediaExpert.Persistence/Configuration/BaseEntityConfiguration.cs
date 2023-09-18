using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskMediaExpert.Domain.Entity;

namespace TaskMediaExpert.Persistence.Configuration
{
    public abstract class BaseEntityConfiguration<TKey, TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        private readonly string _tableName;

        protected BaseEntityConfiguration(string tableName)
        {
            this._tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(_tableName);
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(x => x.IsActive);
        }
    }
}

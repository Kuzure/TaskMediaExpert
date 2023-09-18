namespace TaskMediaExpert.Domain.Entity
{
    public abstract class BaseEntity
    {

    }
    public abstract class BaseEntity<TKey> : BaseEntity where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LmDate { get; set; }
        public bool IsActive { get; set; }
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            IsActive = true;
        }
    }
}

namespace TaskMediaExpert.Domain.Entity
{
    public class Product : BaseEntity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

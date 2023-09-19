using MediatR;

namespace TaskMediaExpert.Application.CQRS.Product.Command
{
    public class AddProductCommand : IRequest<Domain.Entity.Product>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

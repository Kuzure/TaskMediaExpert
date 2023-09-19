using MediatR;
using TaskMediaExpert.Application.Interface;

namespace TaskMediaExpert.Application.CQRS.Product.Command
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Domain.Entity.Product>
    {
        private readonly IProductRepository _repository;

        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entity.Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entity.Product
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                Price = request.Price,
            };
            await _repository.AddAsync(entity);
            return default!;
        }
    }
}

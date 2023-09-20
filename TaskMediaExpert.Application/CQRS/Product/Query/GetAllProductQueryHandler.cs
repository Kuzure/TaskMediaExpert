using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMediaExpert.Application.Interface;
using TaskMediaExpert.Infrastructure.Models;

namespace TaskMediaExpert.Application.CQRS.Product.Query
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var entities = await _productRepository.GetAllAsync();

            IEnumerable<ProductModel> products = entities.Select(x => new ProductModel() { Id = x.Id, Code = x.Code, Name = x.Name, Price = x.Price });
            return products;

        }
    }
}

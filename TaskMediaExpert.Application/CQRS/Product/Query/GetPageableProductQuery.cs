using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMediaExpert.Infrastructure;
using TaskMediaExpert.Infrastructure.Models;

namespace TaskMediaExpert.Application.CQRS.Product.Query
{
    public class GetPageableProductQuery : IRequest<PaginationResponse<IEnumerable<ProductModel>>>
    {
        private const int MaxItemsPage = 50;
        private int _itemsPerPage;
        public int Page { get; set; } = 1;

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set => _itemsPerPage = value > MaxItemsPage ? MaxItemsPage : value;
        }
    }
}

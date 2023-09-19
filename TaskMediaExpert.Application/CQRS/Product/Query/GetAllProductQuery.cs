using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMediaExpert.Infrastructure.Models;

namespace TaskMediaExpert.Application.CQRS.Product.Query
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductModel>>
    {
    }
}

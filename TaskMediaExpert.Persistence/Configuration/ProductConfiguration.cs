using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMediaExpert.Domain.Entity;
using TaskMediaExpert.Persistence.Configuration;

namespace MTaskMediaExpert.Persistence.Configuration
{
    public class ProductConfiguration : BaseEntityConfiguration<Guid, Product>
    {
        public ProductConfiguration() : base("Product")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.ViewModels.Products
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductListItemViewModel> Products { get; set; }
    }
}

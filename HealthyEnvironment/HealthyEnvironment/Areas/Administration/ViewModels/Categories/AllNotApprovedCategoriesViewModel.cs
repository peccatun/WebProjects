using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.ViewModels.Categories
{
    public class AllNotApprovedCategoriesViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}

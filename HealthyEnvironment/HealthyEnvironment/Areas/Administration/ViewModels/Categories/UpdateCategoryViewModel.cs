using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.ViewModels.Categories
{
    public class UpdateCategoryViewModel
    {
        public string CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }
    }
}

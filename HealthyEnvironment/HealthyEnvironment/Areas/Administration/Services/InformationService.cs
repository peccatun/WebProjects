using HealthyEnvironment.Areas.Administration.ViewModels.Information;
using HealthyEnvironment.Data;
using System.Collections.Generic;
using System.Linq;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public class InformationService : IInformationService
    {
        private readonly ApplicationDbContext dbContext;

        public InformationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<InformationViewModel> GetAllInformation()
        {
            IEnumerable<InformationViewModel> information = this.dbContext
                .Information
                .OrderByDescending(i => i.CreatedOn)
                .Select(i => new InformationViewModel
                {
                    About = i.About,
                    ImageUrl = i.ImageUrl == null ? "https://us.123rf.com/450wm/pavelstasevich/pavelstasevich1811/pavelstasevich181101065/112815953-stock-vector-no-image-available-icon-flat-vector.jpg?ver=6" : i.ImageUrl,
                    InformationId = i.Id
                })
                .ToList();

            return information;
        }
    }
}

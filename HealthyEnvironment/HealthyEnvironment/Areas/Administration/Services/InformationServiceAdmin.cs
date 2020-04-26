using HealthyEnvironment.Areas.Administration.ViewModels.Information;
using HealthyEnvironment.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Services
{
    public class InformationServiceAdmin : IInformationServiceAdmin
    {
        private readonly ApplicationDbContext dbContext;

        public InformationServiceAdmin(ApplicationDbContext dbContext)
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

        public InformationDetailsViewModel GetInformationById(string informationId)
        {
            InformationDetailsViewModel information = this.dbContext
                .Information
                .Where(i => i.Id == informationId)
                .Select(i => new InformationDetailsViewModel
                {
                    InformationId = i.Id,
                    CreatorUserName = i.ApplicationUser.UserName,
                    About = i.About,
                    Content = i.Content,
                    ImageUrl = i.ImageUrl,
                    CreatedOn = i.CreatedOn,
                    CategoryName = i.Category.Name,
                    IsApproved = i.IsApproved,
                    IsDeleted = i.IsDeleted,
                })
                .FirstOrDefault();

            return information;
        }

        public async Task UpdateInformation(UpdateInformationViewModel model)
        {
            var information = dbContext.Information.FirstOrDefault(i => i.Id == model.InformationId);

            information.IsApproved = model.IsApproved;
            information.IsDeleted = model.IsDeleted;

            await dbContext.SaveChangesAsync();
        }
    }
}

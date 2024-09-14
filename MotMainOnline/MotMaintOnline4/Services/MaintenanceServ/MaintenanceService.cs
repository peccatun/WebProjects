using MotMaintOnline4.Data;
using MotMaintOnline4.InputModels.Maintenances;
using MotMaintOnline4.Models;
using MotMaintOnline4.ViewModels.Maintenance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.MaintenanceServ
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly ApplicationDbContext dbContext;

        public MaintenanceService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(MaintenanceInputModel inputModel)
        {
            var maintenance = new Maintenance
            {
                MaintenanceTypeId = inputModel.MaintenanceTypeId,
                ApplicationUserId = inputModel.ApplicationUserId,
                DateDone = inputModel.DateDone,
                Description = inputModel.Description,
                IsDel = false,
                Price = inputModel.Price,
                Kilometers = inputModel.Kilometers,
                MotorcycleId = inputModel.MotorcycleId,
            };

            await dbContext.Maintenances.AddAsync(maintenance);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<MaintenanceViewModel> GetMaintenances(int motorcycleId)
        {
            var maintenances = dbContext
                .Maintenances
                .Where(m => m.MotorcycleId == motorcycleId)
                .Select(m => new MaintenanceViewModel
                {
                    DateDone = m.DateDone.ToString("dd.MM.yyyy"),
                    Description = m.Description,
                    Id = m.Id,
                    KilometersOnChange = m.Kilometers,
                    MaintenanceType = m.MaintenanceType.Type,
                    MaintenanceTypeId = m.MaintenanceTypeId,
                    MotorcycleId = m.MotorcycleId,
                    Price = m.Price,
                })
                .ToList();

            return maintenances;
        }
    }
}

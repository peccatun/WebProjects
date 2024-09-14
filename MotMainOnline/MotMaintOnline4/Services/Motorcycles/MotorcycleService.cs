using MotMaintOnline4.Data;
using MotMaintOnline4.Dtos.MaintenanceTypes;
using MotMaintOnline4.InputModels.Motorcycles;
using MotMaintOnline4.Models;
using MotMaintOnline4.ViewModels.Maintenance;
using MotMaintOnline4.ViewModels.Motorcycles;
using System.Linq;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.Motorcycles
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext dbContext;

        public MotorcycleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(MotorcycleInputModel inputModel)
        {
            var motorcycle = new Motorcycle
            {
                ApplicationUserId = inputModel.ApplicationUserId,
                IsDel = false,
                Make = inputModel.Make,
                ProductionDate = inputModel.ProductionDate,
                Model = inputModel.Model,
                StartKilometers = inputModel.StartKilometers,
            };

            await dbContext.Motorcycles.AddAsync(motorcycle);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var motorcycle = dbContext
                .Motorcycles
                .Where(m => m.Id == id)
                .FirstOrDefault();

            motorcycle.IsDel = true;

            await dbContext.SaveChangesAsync();
        }

        public DetailsViewModel Details(int id)
        {
            const string DateTimeFormat = "dd.MM.yyyy";

            var details = dbContext
                .Motorcycles
                .Where(m => m.Id == id)
                .Select(m => new DetailsViewModel 
                {
                    Id = m.Id,
                    Kilometers = m.StartKilometers,
                    Make = m.Make,
                    Model = m.Model,
                    ProductionDate = m.ProductionDate.ToString(DateTimeFormat),
                    Maintenances = m.Maintenances
                        .Where(maintenance => !maintenance.IsDel)
                        .Select(maintenance => new MaintenanceViewModel
                        {
                            DateDone = maintenance.DateDone.ToString(DateTimeFormat),
                            Description = maintenance.Description,
                            Id = maintenance.Id,
                            KilometersOnChange = maintenance.Kilometers,
                            MaintenanceType = maintenance.MaintenanceType.Type,
                            MaintenanceTypeId = maintenance.MaintenanceTypeId,
                            MotorcycleId = maintenance.MotorcycleId,
                            Price = maintenance.Price,
                        })
                        .ToArray(),
                    MaintenanceTypes = dbContext
                        .MaintenanceTypes
                        .Where(mt => !mt.IsDel)
                        .Select(mt => new MaintenanceTypeDto 
                        {
                            Id = mt.Id,
                            Type = mt.Type,
                        })
                        .ToArray(),
                })
                .FirstOrDefault();

            return details;
        }

        public async Task Edit(MotorcycleInputModel inputModel)
        {
            var motorcycle = dbContext
                .Motorcycles
                .Where(m => m.Id == inputModel.Id)
                .FirstOrDefault();

            motorcycle.Make = inputModel.Make;
            motorcycle.Model = inputModel.Model;
            motorcycle.ProductionDate = inputModel.ProductionDate;
            motorcycle.StartKilometers = inputModel.StartKilometers;

            await dbContext.SaveChangesAsync(); 
        }

        public int GetMotorcycleUserId(int motorcycleId)
        {
            return dbContext
                .Motorcycles
                .Where(m => m.Id == motorcycleId)
                .Select(m => m.ApplicationUserId)
                .FirstOrDefault();
        }
    }
}

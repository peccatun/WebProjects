using MotMaintOnline4.Data;
using MotMaintOnline4.InputModels.Motorcycles;
using MotMaintOnline4.Models;
using MotMaintOnline4.ViewModels.Motorcycles;
using System.Collections.Generic;
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
            Motorcycle motorcycle = new Motorcycle
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
            Motorcycle motorcycle = dbContext
                        .Motorcycles
                        .Where(m => m.Id == id)
                        .FirstOrDefault();

            motorcycle.IsDel = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task Edit(MotorcycleInputModel inputModel)
        {
            Motorcycle motorcycle = dbContext
                                    .Motorcycles
                                    .Where(m => m.Id == inputModel.Id)
                                    .FirstOrDefault();

            motorcycle.Make = inputModel.Make;
            motorcycle.Model = inputModel.Model;
            motorcycle.ProductionDate = inputModel.ProductionDate;
            motorcycle.StartKilometers = inputModel.StartKilometers;

            await dbContext.SaveChangesAsync(); 
        }

        public IEnumerable<MotorcycleViewModel> UserMotorcycles(int userId)
        {
            IEnumerable<MotorcycleViewModel> motorcycles = dbContext
                                                .Motorcycles
                                                .Where(m => !m.IsDel && m.ApplicationUserId == userId)
                                                .Select(m => new MotorcycleViewModel
                                                {
                                                    Id = m.Id,
                                                    Make = m.Make,
                                                    Model = m.Model,
                                                    ProductionYear = m.ProductionDate,
                                                    Kilometers = m.StartKilometers,
                                                })
                                                .ToList();

            return motorcycles;
        }
    }
}

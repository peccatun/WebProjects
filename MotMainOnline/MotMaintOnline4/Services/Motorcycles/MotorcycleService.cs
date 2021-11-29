using MotMaintOnline4.Data;
using MotMaintOnline4.ViewModels.Motorcycles;
using System.Collections.Generic;
using System.Linq;

namespace MotMaintOnline4.Services.Motorcycles
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext dbContext;

        public MotorcycleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                                                    ProductionYear = m.ProductionDate
                                                })
                                                .ToList();

            return motorcycles;
        }
    }
}

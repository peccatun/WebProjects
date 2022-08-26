using MotMaintOnline4.Data;
using System.Threading.Tasks;
using MotMaintOnline4.Models;
using System.Collections.Generic;
using MotMaintOnline4.Dtos.MaintenanceTypes;
using System.Linq;

namespace MotMaintOnline4.Services.MaintenanceTypeServ
{
    public class MaintenanceTypeService : IMaintenanceTypeService
    {
        private readonly ApplicationDbContext dbContext;

        public MaintenanceTypeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(string type)
        {
            MaintenanceType maintenanceType = new MaintenanceType
            {
                IsDel = false,
                Type = type,
            };

            await dbContext.MaintenanceTypes.AddAsync(maintenanceType);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<MaintenanceTypeDto> GetAll()
        {
            var maitenanceTypes = dbContext
                .MaintenanceTypes
                .Where(mt => !mt.IsDel)
                .Select(mt => new MaintenanceTypeDto
                {
                    Id = mt.Id,
                    Type = mt.Type,
                })
                .ToList();

            return maitenanceTypes;
        }
    }
}

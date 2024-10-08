﻿using MotMaintOnline4.Data;
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
    }
}

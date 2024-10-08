﻿using MotMaintOnline4.Data;
using MotMaintOnline4.ViewModels.ApplicationUser;
using MotMaintOnline4.InputModels.ApplicationUser;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MotMaintOnline4.ViewModels.Motorcycles;

namespace MotMaintOnline4.Services.ApplicationUser
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicationUserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(ApplicationUserInputModel inputModel)
        {
            var applicationUser = new Models.ApplicationUser
            {
                IsDel = false,
                Name = inputModel.Name,
            };

            await dbContext.ApplicationUsers.AddAsync(applicationUser);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = dbContext
                .ApplicationUsers
                .Where(ap => ap.Id == id)
                .FirstOrDefault();

            user.IsDel = true;

            await dbContext.SaveChangesAsync(); 
        }

        public async Task Edit(ApplicationUserInputModel inputModel)
        {
            var applicationUser = dbContext
                .ApplicationUsers
                .Where(au => au.Id == inputModel.Id)
                .FirstOrDefault();

            applicationUser.Name = inputModel.Name;

            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<ApplicationUserViewModel> GetApplicationUsers()
        {
            var appUsers = dbContext
                .ApplicationUsers
                .Where(ap => !ap.IsDel)
                .Select(ap => new ApplicationUserViewModel
                {
                    Id = ap.Id,
                    Name = ap.Name,
                })
                .ToArray();

            return appUsers;
        }

        public UserDetailsViewModel UserDetails(int id)
        {
            var viewModel = dbContext
                .ApplicationUsers
                .Where(au => au.Id == id)
                .Select(au => new UserDetailsViewModel 
                {
                    Id = au.Id,
                    Name = au.Name,
                    Motorcycles = au.Motorcycles
                        .Where(m => !m.IsDel)
                        .Select(m => new MotorcycleViewModel 
                        {
                            Id = m.Id,
                            Make = m.Make,
                            Model = m.Model,
                            ProductionYear = m.ProductionDate,
                            Kilometers = m.StartKilometers,
                        })
                        .ToArray(),
                })
                .FirstOrDefault();

            return viewModel;
                                            
        }
    }
}

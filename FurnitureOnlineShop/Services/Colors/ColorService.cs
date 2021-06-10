using FurnitureOnlineShop.Areas.Administration.InputModels.Colors;
using FurnitureOnlineShop.Areas.Administration.ViewModels;
using FurnitureOnlineShop.Data;
using System.Collections.Generic;
using System.Linq;
using FurnitureOnlineShop.Models;

namespace FurnitureOnlineShop.Services.Colors
{
    public class ColorService : IColorService
    {
        private readonly ApplicationDbContext dbContext;
        public ColorService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddColor(ColorInputModel model)
        {
            Color color = new Color
            {
                IsDeleted = model.IsDeleted,
                ColorName = model.ColorName,
            };

            dbContext.Colors.Add(color);
            dbContext.SaveChanges();
        }

        public List<ColorViewModel> GetColors()
        {
            List<ColorViewModel> colors = dbContext.Colors
                .Where(c => !c.IsDeleted)
                .Select(c => new ColorViewModel
                {
                    Text = c.ColorName,
                    Value = c.Id.ToString(),
                })
                .ToList();

            return colors;
        }
    }
}

using FurnitureOnlineShop.Areas.Administration.InputModels.Colors;
using FurnitureOnlineShop.Areas.Administration.ViewModels;
using System.Collections.Generic;

namespace FurnitureOnlineShop.Services.Colors
{
    public interface IColorService
    {
        List<ColorViewModel> GetColors();

        void AddColor(ColorInputModel model);
    }
}

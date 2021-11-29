using MotMaintOnline4.ViewModels.Motorcycles;
using System.Collections.Generic;

namespace MotMaintOnline4.Services.Motorcycles
{
    public interface IMotorcycleService
    {
        IEnumerable<MotorcycleViewModel> UserMotorcycles(int userId);
    }
}

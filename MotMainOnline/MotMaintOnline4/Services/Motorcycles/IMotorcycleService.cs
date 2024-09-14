using MotMaintOnline4.InputModels.Motorcycles;
using MotMaintOnline4.ViewModels.Motorcycles;
using System.Threading.Tasks;

namespace MotMaintOnline4.Services.Motorcycles
{
    public interface IMotorcycleService
    {
        Task Create(MotorcycleInputModel inputModel);

        Task Edit(MotorcycleInputModel inputModel);

        Task Delete(int id);

        DetailsViewModel Details(int id);

        int GetMotorcycleUserId(int motorcycleId);
    }
}

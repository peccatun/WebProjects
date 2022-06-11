using ImageViewer.InputModels.Images;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImageViewer.Services
{
    public interface IImageService
    {
        Task ProcessAsync(IEnumerable<ImageInputModel> inputModel);

        Task ProcessToDb(IEnumerable<ImageInputModel> inputModel);

        Task<Stream> GetThumbnail(string id);

        Task<Stream> GetFullscreen(string id);

        Task<Stream> GetOriginal(string id);

        Task<List<string>> GetAllImages();
    }
}

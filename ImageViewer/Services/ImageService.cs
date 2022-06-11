using ImageViewer.InputModels.Images;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using ImageViewer.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;

namespace ImageViewer.Services
{
    public class ImageService : IImageService
    {
        private const int TumbnailWidth = 300;
        private const int FullscreenWidth = 1000;

        private readonly ApplicationDbContext dbContext;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ImageService(
            IServiceScopeFactory serviceScopeFactory,
            ApplicationDbContext dbContext)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.dbContext = dbContext;
        }

        public async Task<List<string>> GetAllImages()
        {

            return await dbContext.ImageData.Select(id => id.Id.ToString()).ToListAsync();
        }

        public async Task<Stream> GetFullscreen(string id)
        {
            return await GetImageData(id, "FullscreenContent");
        }

        public async Task<Stream> GetOriginal(string id)
        {
            return await GetImageData(id, "OriginalContent");
        }

        public async Task<Stream> GetThumbnail(string id)
        {
            return await GetImageData(id, "ThumbnailContent");
        }

        public async Task ProcessAsync(IEnumerable<ImageInputModel> inputModel)
        {
            var tasks = new List<Task>();

            foreach (var image in inputModel)
            {
                tasks.Add(Task.Run(async () =>
                    {
                        using var imageResult = await Image.LoadAsync(image.Content);

                        await SaveImage(imageResult, $"Original_{image.Name}", imageResult.Width);
                        await SaveImage(imageResult, $"Fullscreen_{image.Name}", FullscreenWidth);
                        await SaveImage(imageResult, $"Tumbnail_{image.Name}", TumbnailWidth);
                    }));
            }

            await Task.WhenAll(tasks);
        }

        public async Task ProcessToDb(IEnumerable<ImageInputModel> inputModel)
        {
            List<Task> tasks = new List<Task>();

            foreach (var image in inputModel)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var imageResult = await Image.LoadAsync(image.Content);

                    var original = await SaveImageToDb(imageResult, imageResult.Width);
                    var fullscreen = await SaveImageToDb(imageResult, FullscreenWidth);
                    var thumbnail = await SaveImageToDb(imageResult, TumbnailWidth);

                    var data = serviceScopeFactory
                            .CreateScope()
                            .ServiceProvider
                            .GetRequiredService<ApplicationDbContext>();

                    await data.ImageData.AddAsync(new ImageData
                    {
                        OriginalFileName = image.Name,
                        OriginalType = image.Type,
                        OriginalContent = original,
                        FullscreenContent = fullscreen,
                        ThumbnailContent = thumbnail,
                    });

                    await data.SaveChangesAsync();
                }));
            }

            await Task.WhenAll(tasks);
        }

        private async Task SaveImage(Image image, string name, int sizeWidth)
        {
            var width = image.Width;
            var height = image.Height;

            if (width > sizeWidth)
            {
                height = (int)((double)sizeWidth / width * height);
                width = sizeWidth;
            }

            image.Mutate(i => i
            .Resize(new Size(width, height)));

            image.Metadata.ExifProfile = null;

            await image.SaveAsJpegAsync(name, new JpegEncoder
            {
                Quality = 75
            });
        }

        private async Task<byte[]> SaveImageToDb(Image image, int sizeWidth)
        {
            int width = image.Width;
            int height = image.Height;

            if (width > sizeWidth)
            {
                height = sizeWidth / width * height;
                width = sizeWidth;
            }

            image.Mutate(i => i.Resize(new Size(width, height)));

            image.Metadata.ExifProfile = null;

            using var memoryStream = new MemoryStream();

            await image.SaveAsJpegAsync(memoryStream, new JpegEncoder { Quality = 75 });

            return memoryStream.ToArray();
        }

        private async Task<Stream> GetImageData(string id, string size) 
        {
            var database = dbContext.Database;

            Stream result = null;
            using (var dbConnection = (SqlConnection)database.GetDbConnection())
            {
                string selectStatement = $"select id.{size} from ImageData id where cast(id.Id as varchar(max)) = '{id}'";
                var command = new SqlCommand(selectStatement, dbConnection);
                await dbConnection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result = reader.GetStream(0);
                        }
                    }
                }
            }

            return result;
        }
    }
}

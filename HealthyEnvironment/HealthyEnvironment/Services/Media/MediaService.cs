using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HealthyEnvironment.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Media
{
    public class MediaService : IMediaService
    {
        private readonly Cloudinary cloudinary;

        public MediaService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }
        public async Task<string> UploadPictureAsync(IFormFile file)
        {
            byte[] destinationImage;
            string path = string.Empty;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream)
                    };

                    var uploadResult = await cloudinary.UploadAsync(uploadParams);
                    path = uploadResult.Uri.AbsoluteUri;
                }
            }

            return path;
        }
    }
}

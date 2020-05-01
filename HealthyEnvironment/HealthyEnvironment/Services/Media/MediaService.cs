using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HealthyEnvironment.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HealthyEnvironment.Services.Media
{
    public class MediaService : IMediaService
    {
        private readonly Cloudinary cloudinary;

        public MediaService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public string[] ConvertJsonToStringArray(string json)
        {
            if (json == null)
            {
                return null;
            }

            string[] jsonToArray = JsonConvert.DeserializeObject<string[]>(json);

            return jsonToArray;
        }

        public async Task<string> UploadMultiplePicturesAsync(IFormFile[] files)
        {
            if (files == null)
            {
                return null;
            }

            if (files.Count() == 0)
            {
                return null;
            }

            List<string> imageUrls = new List<string>();

            foreach (var file in files)
            {
                string imageUrl = await UploadPictureAsync(file);
                imageUrls.Add(imageUrl);
            }

            var json = JsonConvert.SerializeObject(imageUrls);

            return json;
        }

        public async Task<string> UploadPictureAsync(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            if (!IsValidFormat(file.FileName))
            {
                return null;
            }

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

        private bool IsValidFormat(string fileName)
        {
            List<string> validFormats = new List<string>
            {
                ".png",".bmp",".dib",".jpg",".jpeg",".jpe",
                ".jfif",".tif",".tiff",".heic,"
            };

            foreach (var format in validFormats)
            {
                if (fileName.EndsWith(format))
                {
                    return true;
                }
            }

            return false; ;
        }
    }
}

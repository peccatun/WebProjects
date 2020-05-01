using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Media
{
    public interface IMediaService
    {
        Task<string> UploadPictureAsync(IFormFile file);

        Task<string> UploadMultiplePicturesAsync(IFormFile[] files);

        string[] ConvertJsonToStringArray(string json);
    }
}

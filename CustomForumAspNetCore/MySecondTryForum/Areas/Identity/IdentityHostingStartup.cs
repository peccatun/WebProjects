using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySecondTryForum.Data;
using MySecondTryForum.Models;

[assembly: HostingStartup(typeof(MySecondTryForum.Areas.Identity.IdentityHostingStartup))]
namespace MySecondTryForum.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });

        }
    }
}
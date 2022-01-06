using System;
using FCVoetbal.Data;
using FCVoetbal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FCVoetbal.Areas.Identity.IdentityHostingStartup))]
namespace FCVoetbal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VoetbalContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LocalDBConnection")));
            });
        }
    }
}
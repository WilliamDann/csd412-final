using System;
using csd412_final.Areas.Identity.Data;
using csd412_final.Data;
using csd412_final.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(csd412_final.Areas.Identity.IdentityHostingStartup))]
namespace csd412_final.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<csd412_finalContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("csd412_finalContextConnection")));

                services.AddDefaultIdentity<csd412_finalUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<csd412_finalContext>();
            });
        }
    }
}
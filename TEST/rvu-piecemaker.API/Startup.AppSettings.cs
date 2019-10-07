using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RvuPiecemaker.API
{
    public partial class Startup
    {
        public static void ConfigureAppSettings(IServiceCollection services, IConfiguration cfg)
        {
            //AppSettings asks for IConfigurationRoot to strongly type it.
            services.AddScoped<IConfiguration>(x => cfg);
        }
    }
}

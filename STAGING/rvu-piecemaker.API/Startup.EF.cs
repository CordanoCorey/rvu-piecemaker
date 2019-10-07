using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RvuPiecemaker.Entities.Context;

namespace RvuPiecemaker.API
{
  public partial class Startup
  {
    public static void ConfigureOrmServices(IConfiguration Configuration, IServiceCollection services)
    {
      services.AddEntityFrameworkSqlServer().AddDbContext<RvuPiecemakerContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("rvu"));
      });
    }

    public static void ConfigureOrm(IApplicationBuilder app, IHostingEnvironment env)
    {
      //using (var serviceScope = app.ApplicationServices
      //.GetRequiredService<IServiceScopeFactory>()
      //.CreateScope())
      //{
      //    using (var context = serviceScope.ServiceProvider.GetService<RvuPiecemakerContext>())
      //    {
      //        var isInit = !context.Database.GetAppliedMigrations().Any();
      //        context.Database.Migrate();
      //    }
      //}
    }
  }
}

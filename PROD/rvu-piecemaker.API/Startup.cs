using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using CAIU.Common;
using CAIU.Common.ResetPassword;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RvuPiecemaker.API.Features.Calendars;
using RvuPiecemaker.API.Features.Exams;
using RvuPiecemaker.API.Features.Goals;
using RvuPiecemaker.API.Features.Shifts;
using RvuPiecemaker.API.Features.ExamGroups;
using RvuPiecemaker.API.Features.Users;
using RvuPiecemaker.API.Features.Services;

namespace RvuPiecemaker.API
{
  public partial class Startup
  {
    private MapperConfiguration _mapperConfiguration { get; set; }
    public Startup(IHostingEnvironment env)
    {
      //Set up AutoMapper
      _mapperConfiguration = new MapperConfiguration(config =>
      {
        config.AddProfile(new CalendarsMapProfile());
        config.AddProfile(new ExamsMapProfile());
        config.AddProfile(new GoalsMapProfile());
        config.AddProfile(new ServicesMapProfile());
        config.AddProfile(new ShiftsMapProfile());
        config.AddProfile(new ExamGroupsMapProfile());
        config.AddProfile(new UsersMapProfile());
      });

      var builder = new ConfigurationBuilder()
      .SetBasePath(env.ContentRootPath)
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
      .AddJsonFile("localConnectionStrings.json", optional: true);

      if (env.IsEnvironment("Development"))
      {
        //dev specific things
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      ConfigureAppSettings(services, Configuration);
      //Cross-origin Resource Sharing
      //Browsers will shut down POSTs across domains if preflight doesn't work.
      //https://en.wikipedia.org/wiki/Cross-origin_resource_sharing#Simple_example
      ConfigureCorsServices(services);

      services.AddMvc().AddJsonOptions(options =>
      {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      });

      //EF, Dapper, database related stuff would go here.
      ConfigureOrmServices(Configuration, services);

      //Add MVC.
      services.AddMvc();

      //Identity/IdentityServer/Token generation.
      ConfigureAuthServices(Configuration, services);

      //API Documentation.
      ConfigureSwaggerServices(services);

      //TODO: Separate method if many singletons are needed?
      // Once per lifetime services
      // HttpClient is special because nobody at Microsoft cares about IDisposable
      //http://stackoverflow.com/questions/15705092/do-httpclient-and-httpclienthandler-have-to-be-disposed
      services.AddSingleton<IHttpClient, HttpClientWrapper>();

      services.AddSingleton(sp => _mapperConfiguration.CreateMapper());

      // Filters.
      // TODO: As app grows, filters should have its own method?
      //services.AddScoped<ModelValidationFilter>();

      //Scoped Services
      ConfigureScopedServices(services);

      //Add Reset Password API endpoints
      services.AddMvc().AddApplicationPart(typeof(ResetPasswordController).GetTypeInfo().Assembly);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      ConfigureCors(app, env);

      ConfigureOrm(app, env);

      // CAIU.Common.Startup.LogErrorsAndReturnFriendlyResponseToClient<OasisContext>(app, env, loggerFactory);
      ConfigureErrors(app, services, loggerFactory);

      ConfigureAuth(app, env, loggerFactory, Configuration);

      app.UseMvc();

      ConfigureSwagger(app, env);
    }
  }
}

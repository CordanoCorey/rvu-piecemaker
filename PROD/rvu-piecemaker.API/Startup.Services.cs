using CAIU.Common.ResetPassword;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RvuPiecemaker.API.Features.Calendars;
using RvuPiecemaker.API.Features.Exams;
using RvuPiecemaker.API.Features.Goals;
using RvuPiecemaker.API.Features.Services;
using RvuPiecemaker.API.Features.Shifts;
using RvuPiecemaker.API.Features.ExamGroups;
using RvuPiecemaker.API.Features.Users;
using RvuPiecemaker.API.Infrastructure.Lookup;

namespace RvuPiecemaker.API
{
  public partial class Startup
  {
    public static void ConfigureScopedServices(IServiceCollection services)
    {
      //Shared
      services.AddScoped<ILookupRepository, LookupRepository>();

      //Calendars
      services.AddScoped<ICalendarsService, CalendarsService>();
      services.AddScoped<ICalendarsRepository, CalendarsRepository>();
      services.AddScoped<ICalendarEventsRepository, CalendarEventsRepository>();

      //Exams
      services.AddScoped<IExamsService, ExamsService>();
      services.AddScoped<IExamsRepository, ExamsRepository>();
      services.AddScoped<IExamTypesRepository, ExamTypesRepository>();

      //Goals
      services.AddScoped<IGoalsService, GoalsService>();
      services.AddScoped<IGoalsRepository, GoalsRepository>();

      // Reset Password
      services.AddScoped<IResetPasswordRepository, UsersRepository>();
      services.AddScoped<IResetPasswordService, ResetPasswordService>();

      //Services
      services.AddScoped<IServicesService, ServicesService>();
      services.AddScoped<IServicesRepository, ServicesRepository>();

      //Shifts
      services.AddScoped<IShiftsService, ShiftsService>();
      services.AddScoped<IShiftsRepository, ShiftsRepository>();

      //ExamGroups
      services.AddScoped<IExamGroupsService, ExamGroupsService>();
      services.AddScoped<IExamGroupsRepository, ExamGroupsRepository>();

      //Users
      services.AddScoped<IUsersService, UsersService>();
      services.AddScoped<IUsersRepository, UsersRepository>();
    }
  }
}

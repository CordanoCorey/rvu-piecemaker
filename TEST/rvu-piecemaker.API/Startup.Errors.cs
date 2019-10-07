using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CAIU.Common;

namespace RvuPiecemaker.API
{
    public partial class Startup
    {
        public static void ConfigureErrors(IApplicationBuilder app, IServiceProvider services, ILoggerFactory logger)
        {
            // logger.AddProvider(provider: new ErrorLogProvider<RvuPiecemakerContext>(services));

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    //UseExceptionHandler calls clear on Response.Headers whixh removes our CORS headers.
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                    var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        await context.Response.WriteAsync(new ErrorResponse { Code = (int)HttpStatusCode.InternalServerError, Message = String.IsNullOrEmpty(error.Error.Message) ?  "An error has occured in the api." : error.Error.Message }.ToString()).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}

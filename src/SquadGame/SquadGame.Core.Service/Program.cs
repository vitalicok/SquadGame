using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using SquadGame.Api.Base.Configurations;
using SquadGame.Api.Base.Extensions;
using SquadGame.Api.Base.Filters;
using SquadGame.Api.Base.Settings;
using SquadGame.Core.Service.Client;
using SquadGame.Core.Service.Configurations;
using SquadGame.Core.Service.Interfaces;
using SquadGame.Core.Service.Services;


public class Program
{
    public static void Main(string[] args)
    {
        LoggersSetting loggersSettings = new();
        ServiceConfigurations serviceConfiguration = new();
        SqlServerConfiguration sqlServerConfiguration = new();
        SquadApiConfigurations apiConfiguration = new();

        var builder = WebApplication.CreateBuilder(args);

        var logger = new LoggerConfiguration()
                .UseConsoleLogger(loggersSettings.ConsoleLogger)
                .UseFileLogger(loggersSettings.FileLogger)
                //.UseApplicationInsights(loggersSettings.ApplicationInsightsLogger) add once applicable
                .MinimumLevel.Verbose()
                .CreateLogger();

        Log.Logger = logger;
        builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);
        
        builder.Configuration.GetSection(LoggersSetting.SectionName).Bind(loggersSettings);
        builder.Configuration.GetSection(ServiceConfigurations.SectionName).Bind(serviceConfiguration);
        builder.Configuration.GetSection(SqlServerConfiguration.SectionName).Bind(sqlServerConfiguration);
        builder.Services.Configure<SquadApiConfigurations>(builder.Configuration.GetSection(SquadApiConfigurations.SectionName));
        builder.Services.AddSingleton(resolver =>
            resolver.GetRequiredService<IOptions<SquadApiConfigurations>>().Value
        );

        var serviceConfig = new ServiceConfigurations();
        builder.Configuration.GetSection(ServiceConfigurations.SectionName).Bind(serviceConfig);
        builder.Services.AddSingleton(serviceConfig);

        builder.Services.AddScoped<ITeamService, TeamsService>();
        builder.Services.AddScoped<IFootballApiClient, FootballApiClient>();
        builder.Services.AddScoped<ITeamDTOAggregatorService, TeamDTOAggregatorService>();

        builder.Services.AddControllers(options => options.Filters.Add(typeof(APIExceptionFilterAttribute))).AddNewtonsoftJson();
        builder.Services.AddAPICors(serviceConfiguration.AllowedOrigins);
        builder.Services.AddVersionedAPIWithSwagger();
        builder.Services.AddVersionedApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHttpClient();
        builder.Services.AddRateLimit(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
            app.UseHttpsRedirection();
        }

        app.UseCors();
        app.UseRouting();

        app.UseIpRateLimiting();

        app.MapControllers();

        app.Run();
    }
}
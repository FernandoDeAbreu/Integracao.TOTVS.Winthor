using Autofac;
using Autofac.Extensions.DependencyInjection;
using Integracao.TOTVS.Winthor.CrossCute;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ModuleIoc()));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
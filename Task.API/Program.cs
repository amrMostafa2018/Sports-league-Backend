using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System.Globalization;
using Serilog;
using Task.Application;
using Task.Core.Resources;
using Task.Shared.Directories;
using Task.Shared.Settings;
using Task.Core.Domains;



var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
                      .ReadFrom.Configuration(builder.Configuration)
                      .Enrich.FromLogContext()
                      .CreateLogger();
builder.Host.UseSerilog(logger);

builder.Services.AddControllers();

// Add Localization
builder.Services.AddLocalization();
builder.Services.AddMvc().AddDataAnnotationsLocalization(o => o.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Resource)));


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDependencyInjectionServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//Set urlBackEnd form Configuration
HostUrl._urlBackEnd = builder.Configuration.GetValue<string>("urlBackEnd");

builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "TasK API", Version = "1.0" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

var attachmentDirectory = Path.Combine(Directory.GetCurrentDirectory(), Directories.Attachments);
if (!Directory.Exists(attachmentDirectory))
    Directory.CreateDirectory(attachmentDirectory);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(attachmentDirectory),
    RequestPath = "/" + Directories.Attachments
});

// Add Localization
app.UseRouting();

IList<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("ar"),
                    new CultureInfo("en-US")
                };
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
    //SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
};
localizationOptions.RequestCultureProviders.Clear();
localizationOptions.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
app.UseRequestLocalization(localizationOptions);

//app.UseCors("EnableSVCCors");
app.UseCors(
                 options => options
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                );

app.UseAuthentication();
app.UseAuthorization();
//app.UseCors("CorsPolicy");



app.MapControllers();


app.Run();

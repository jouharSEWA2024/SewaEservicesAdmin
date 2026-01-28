using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Serilog;
using SEWAEContractorApplication.Interfaces;
using SEWAEContractorInfrastructure.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options=>options.ResourcesPath="Resources");
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization();
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] {
    new CultureInfo("en-US"),
    new CultureInfo("ar-AE"),
    //new CultureInfo("ja-JP"),
    //new CultureInfo("zh-Hans"),

};
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures= supportedCultures;   
    options.SupportedUICultures= supportedCultures;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue; 
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});
builder.Services.AddTransient<IUserMasterRepository, UserMasterRepository>();
builder.Services.AddTransient<IIssueAuthorityMasterRepository, IssueAuthorityMasterRepository>();
builder.Services.AddTransient<IExternalRepository, ExternalRepository>();
builder.Services.AddTransient<ISMSRepository, SMSRepository>();
builder.Services.AddTransient<ISRRepository, SRRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IFileUploadRepository, FileUploadRepository>();
builder.Services.AddTransient<IBPRepository, BPRepository>();
builder.Services.AddTransient<IIDTypeMasterRepository, IDTypeMasterRepository>();  
builder.Services.AddTransient<ICityMasterRepository, CityMasterRepository>();
builder.Services.AddTransient<IAccountTypeMasterRepository, AccountTypeMasterRepository>();
builder.Services.AddTransient<ISubServiceTypeMasterRepository, SubServiceTypeMasterRepository>();  
builder.Services.AddTransient<IServiceTypeMasterRepository, ServiceTypeMasterRepository>();
builder.Services.AddTransient<ISAPDocumentTypeMasterRepository, SAPDocumentTypeMasterRepository>();
builder.Services.AddTransient<IAreaRepository, AreaRepository>();
builder.Services.AddTransient<ISEDDRepository, SEDDRepository>();
builder.Services.AddTransient<IGovernmentBPMasterRepository, GovernmentBPMasterRepository>();  
builder.Services.AddTransient<ICommonRepository, CommonRepository>(); 
builder.Services.AddTransient<IRealEstateRepository, RealEstateRepository>(); 
builder.Services.AddTransient<IInspectionTypeRepository, InspectionTypeRepository>();
builder.Services.AddTransient<IConnectionRepository, ConnectionRepository>();
builder.Services.AddTransient<ILandDepartmentRepository, LandDepartmentRepository>();
builder.Services.AddTransient<ITownPlanningRepository, TownPlanningRepository>();
builder.Services.AddTransient<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddTransient<ITeamsRepository,TeamsRepository>();
builder.Services.AddTransient<IGoogleCaptchaRepository, GoogleCaptchaRepository>();
builder.Services.AddTransient<IBankRepository, BankRepository>();
builder.Services.AddTransient<IConsumerRepository, ConsumerRepository>();   
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();
builder.Services.AddTransient<IActiveDirectoryService, ActiveDirectoryService>();
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);
app.UseSession();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=AdminLogin}/{id?}");

app.Run();

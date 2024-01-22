using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ProofOfConceptBLZ.Data.WeatherForecastService>();
builder.Services.AddTransient<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddTransient<IPeopleData, PeopleData>();

var cs = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
builder.Services.AddDbContext<ProofOfConceptBLZ.Data.DataContext>(options => options.UseSqlServer(cs));

builder.Services.AddIdentity<ProofOfConceptBLZ.Data.ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProofOfConceptBLZ.Data.DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

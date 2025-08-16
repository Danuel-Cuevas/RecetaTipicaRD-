using Microsoft.EntityFrameworkCore;
using RecetaTipicaRD.Application.Contracts;
using RecetaTipicaRD.Application.Services;
using RecetaTipicaRD.Infrastructure.Contracts;
using RecetaTipicaRD.Infrastructure.Data;
using RecetaTipicaRD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Database Configuration
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RecetaTipicaRDContext>(options => options.UseSqlServer(dbConnectionString));


//Services configuration
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

//Seed the database with initial data


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using BusinessLogicLayer.TAService;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using College_portal_System.Seeds;

namespace College_portal_System
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("default"))
<<<<<<< HEAD
            ); 
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            builder.Services.AddScoped<TAService>();
=======
            );

            // Identity Configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
>>>>>>> d6417c3a3b5580ef2f739281e31af2b3ad626827
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

            app.UseAuthorization();

            using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await DefaultRoles.SeedRolesAsync(roleManager);
            // await DefaultUsers.SeedAdminUser(userManager);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

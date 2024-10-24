using BusinessLogicLayer.TAService;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using College_portal_System.Seeds;
using BusinessLogicLayer.AdminService.Services;
using BusinessLogicLayer.StudentService;

namespace College_portal_System.Extensions
{
    public static class ConfigureServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {           

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("default"))
            );
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBaseRepository<DataAccessLayer.Entities.Task>, BaseRepository<DataAccessLayer.Entities.Task>>();
            builder.Services.AddScoped<IBaseRepository<Course>, BaseRepository<Course>>();
            builder.Services.AddScoped<IBaseRepository<Department>, DepartmentRepository>();
            builder.Services.AddScoped<TAService>();
            builder.Services.AddScoped<AdminService>();
            builder.Services.AddScoped<TAService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();

            //);

            // Identity Configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

            return builder;
        }
    }
}

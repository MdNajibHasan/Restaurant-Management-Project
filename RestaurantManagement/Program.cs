using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);





//--------------------Configure Services--------------------//
//builder.Services.AddControllersWithViews;

builder.Services.AddRazorPages();

//builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));



builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddXmlSerializerFormatters();

/*builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();*/





//builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDBConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

/*builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>();*/



var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
/*else
{
    app.UseHsts();
}*/






















/*app.UseHttpsRedirection();*/
//app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
/*app.UseMvcWithDefaultRoute();*/
app.UseMvc(async routes =>
{
    
    routes.MapRoute("default", "{controller=Home}/{action=Index}");
});

/*app.UseMvc();*/

app.UseAuthorization();



/*app.UseRouting();*/

app.MapControllers();





/*app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello world");
});*/


app.Run();
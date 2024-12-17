using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheWayShop.AppData;
using TheWayShop.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TheWayShopContextConnection") ?? throw new InvalidOperationException("Connection string 'TheWayShopContextConnection' not found.");

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>();
//builder.Services.AddDefaultIdentity<AppDBContext>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TheWayShopContext>();

builder.Services.AddDistributedMemoryCache();  // Register memory cache service
builder.Services.AddSession(cfg => {           // Configure session options
    cfg.Cookie.Name = "TheWayShop";            // Set the session cookie name
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);  // Set session timeout (30 minutes)
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseSession();

app.UseRouting();

app.UseAuthentication();// nếu không có dòng này thì login thành công vẫn không hiển thị được trạng thái đã đăng nhập
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var roles = new[] { "Admin", "Member" };
//    foreach (var role in roles)
//    {
//        if(!await roleManager.RoleExistsAsync(role))
//            await roleManager.CreateAsync(new IdentityRole(role));
//    }
//}
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//    string email = "admin@admin.com";
//    string password = "Admin123.";
//    if (await userManager.FindByEmailAsync(email) == null)
//    {
//        var user = new AppUser();
//        user.Email = email;
//        user.UserName = email;
//        await userManager.CreateAsync(user, password);

//        await userManager.AddToRoleAsync(user, "Admin");
//    }
//}
app.Run();

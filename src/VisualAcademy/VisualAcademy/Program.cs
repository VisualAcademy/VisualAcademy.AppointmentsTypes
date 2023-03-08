using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;

// ASP.NET Core ���� ������
// ASP.NET Core ���� ����, ���� ����, �̵���� ���� ���� ����Ѵ�.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// �����̳ʿ� ���񽺸� �߰��Ѵ�.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// �� ����
var app = builder.Build();

// Configure the HTTP request pipeline.
// HTTP ��û ������������ �����Ѵ�.
if (app.Environment.IsDevelopment()) {
    // ���� ȯ�濡���� ���̱׷��̼� ��������Ʈ�� ����Ѵ�.
    app.UseMigrationsEndPoint();
}
else {
    // � ȯ�濡���� ���� ó�� �̵����� HSTS �̵��� ����Ѵ�.
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTPS ���𷺼ǰ� ���� ���� �̵��� ����Ѵ�.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ������ ���� �̵��� ����Ѵ�.
app.UseAuthorization();

// ��Ʈ�ѷ� �� Razor ������ �̵��� ����Ѵ�.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// �� ����
app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;

// ASP.NET Core 앱의 생성자
// ASP.NET Core 앱의 구성, 서비스 구성, 미들웨어 구성 등을 담당한다.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 컨테이너에 서비스를 추가한다.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// 앱 빌드
var app = builder.Build();

// Configure the HTTP request pipeline.
// HTTP 요청 파이프라인을 구성한다.
if (app.Environment.IsDevelopment()) {
    // 개발 환경에서는 마이그레이션 엔드포인트를 사용한다.
    app.UseMigrationsEndPoint();
}
else {
    // 운영 환경에서는 예외 처리 미들웨어와 HSTS 미들웨어를 사용한다.
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTPS 리디렉션과 정적 파일 미들웨어를 사용한다.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 인증과 권한 미들웨어를 사용한다.
app.UseAuthorization();

// 컨트롤러 및 Razor 페이지 미들웨어를 사용한다.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// 앱 실행
app.Run();

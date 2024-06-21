using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

#region JWT
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//	.AddJwtBearer("Admin", options =>
//	{
//		options.TokenValidationParameters = new()
//		{
//			ValidateAudience = true,
//			ValidateIssuer = true,
//			ValidateLifetime = true,
//			ValidateIssuerSigningKey = true,
//			ValidIssuer = "www.bkt.com",
//			ValidAudience = "www.bkt.com",
//			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bugün Haziranýn En Uzun Günü"))
//		};
//	});

#endregion
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

#region Role
//builder.Services.AddAuthorization(options =>
//{
//	options.AddPolicy("WriterPolicy", policy =>
//	policy.RequireRole("Writer"));
//	options.AddPolicy("AdminPolicy", policy =>
//	policy.RequireRole("Admin"));
//}); 
#endregion

#region Authorize
//builder.Services.AddAuthentication("SessionScheme")
//	.AddCookie("SessionScheme", options => 
//	{
//		options.Cookie.Name = "AuthenticatonMvc";
//		options.LoginPath = "/Login/Index";
//		options.AccessDeniedPath = "/AdminCategory/Index";
//	});

//builder.Services.AddAuthorization(options =>
//{
//	options.AddPolicy("SessionPolicy", policy =>
//	{
//		policy.RequireClaim("UserSession");
//	});
//}); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using CustomerManangementService.Business.Abstract;
using CustomerManangementService.Business.Concrete;
using CustomerManangementService.DAL.Abstract;
using CustomerManangementService.DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(100);
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IAdminDAL, EFAdminDAL>();
builder.Services.AddScoped<ICustomerDAL, EFCustomerDAL>();
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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();

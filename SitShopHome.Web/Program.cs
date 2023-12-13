using JsonSendRequests.Contracts;
using JsonSendRequests;
using SitShopHome.Web.Middleware;
var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
    builder.Services.AddScoped<ICustomerJsonSendRequest, CustomerJsonSendRequest>();
    builder.Services.AddScoped<IProductsJsonSendRequest, ProductsJsonSendRequest>();
    builder.Services.AddScoped<IProductCategoryJsonSendRequest, ProductCategoryJsonSendRequest>();
    
    builder.Services.AddTransient<CheckAuthMiddleware>();
    
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseStaticFiles();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();

    app.UseCheckAuthMiddleware();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Customers}/{action=LogInSystem}");

    app.Run();

}

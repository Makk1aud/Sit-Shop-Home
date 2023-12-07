using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SitShopHome.Web.Services;

namespace SitShopHome.Web.Middleware;

public static class CheckAuthMiddlewareExt
{
    public static void UseCheckAuthMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CheckAuthMiddleware>();
    }
}

public class CheckAuthMiddleware : IMiddleware
{
    public CheckAuthMiddleware()
    {

    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if(!GlobalData.Application.ContainsKey("Customer") && 
          !(context.Request.Path.Value == "/" || context.Request.Path.Value == "/Customers/Registration"))
        {
            context.Response.Redirect("/");
        }
        await next(context);
    }
}



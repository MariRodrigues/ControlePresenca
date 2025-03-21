using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ControlePresenca.Middlewares;

public class TenantMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var tenantIdClaim = context.User.FindFirst("tenantId")?.Value;

        if (!string.IsNullOrEmpty(tenantIdClaim))
        {
            context.Items["TenantId"] = tenantIdClaim;
        }

        await next(context);
    }
}

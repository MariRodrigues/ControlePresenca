using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ControlePresenca.Infra.Helpers;

public interface IUserContext
{
    int? GetCurrentTenantId();
    string GetCurrentUserRole();
    int? GetCurrentUserId();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public int? GetCurrentTenantId()
    {

        var tenantIdValue = httpContextAccessor.HttpContext?.Items["TenantId"]?.ToString();

        if (int.TryParse(tenantIdValue, out var tenantId))
        {
            return tenantId;
        }

        return null;
    }

    public string GetCurrentUserRole()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
    }

    public int? GetCurrentUserId()
    {
        var userIdString = httpContextAccessor.HttpContext?.User?.FindFirst("userId")?.Value;

        if (int.TryParse(userIdString, out var userId))
        {
            return userId;
        }

        return null;
    }
}
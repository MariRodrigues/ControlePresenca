using ControlePresenca.Domain.Interfaces;
using ControlePresenca.Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Data.Interceptors;

public class MultiTenantSaveChangesInterceptor(IUserContext userContext) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ApplyTenantId(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyTenantId(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void ApplyTenantId(DbContext context)
    {
        if (context == null) return;

        var tenantId = userContext.GetCurrentTenantId();

        var entries = context.ChangeTracker.Entries<IMultiTenantEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.TenantId = tenantId.Value; // Define o TenantId na inserção
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property(nameof(IMultiTenantEntity.TenantId)).IsModified = false;
            }
        }
    }
}

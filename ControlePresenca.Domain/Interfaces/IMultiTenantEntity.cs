using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Interfaces;

public interface IMultiTenantEntity
{
    public int TenantId { get; set; }
}

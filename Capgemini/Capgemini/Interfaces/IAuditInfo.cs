using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Interfaces
{
    public interface IAuditInfo
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}

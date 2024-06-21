using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DomainService
{
    public interface IOrganizationService
    {
        Task<object> GetOrganization();
    }
}

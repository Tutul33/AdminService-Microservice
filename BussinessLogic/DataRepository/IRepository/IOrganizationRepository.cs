using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataRepository
{
    public interface IOrganizationRepository
    {
        Task<OrganizationDTO> Save(OrganizationDTO organization);
        Task<bool> Delete(int id);
    }
}

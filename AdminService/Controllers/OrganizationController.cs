using BussinessLogic;
using BussinessLogic.DataRepository;
using BussinessLogic.DomainService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("CORSPolicy")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationRepository organizationRepository, IOrganizationService organizationService)
        {
            _organizationRepository = organizationRepository;
            _organizationService = organizationService;
        }
        /// <summary>
        /// This methods will store data to database 
        /// </summary>
        /// <param name="organizationDTO"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        public async Task<OrganizationDTO> Save([FromBody]  OrganizationDTO organizationDTO) 
        {
            try
            {
              return await _organizationRepository.Save(organizationDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method will delete data from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<bool> Delete(int id)
        {
            try
            {
              return await _organizationRepository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method will retrieve data from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrganization")]
        public async Task<object> GetOrganization()
        {
            try
            {
                return await _organizationService.GetOrganization();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

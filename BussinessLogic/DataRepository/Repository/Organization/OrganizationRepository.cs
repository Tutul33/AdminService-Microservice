using AutoMapper;
using Data.DataContext.Models;
namespace BussinessLogic.DataRepository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DbProjectContext _context;
        //private readonly IMapper _mapper;
        public OrganizationRepository(DbProjectContext context)//, IMapper mapper)
        {
            _context = context;
            //_mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var org = _context.AdOrganizations.Find(id);
                if (org != null)
                {
                    _context.AdOrganizations.Remove(org);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrganizationDTO> Save(OrganizationDTO organization)
        {
            try
            {
               
                var _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OrganizationDTO, AdOrganization>();
                }).CreateMapper();

                var org = _mapper.Map<AdOrganization>(organization);

                _context.Add(org);
                await _context.SaveChangesAsync();

                return organization;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

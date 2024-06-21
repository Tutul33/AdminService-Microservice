using AdminService.Handler;

namespace AdminService.DIServices
{
    public static class ConfigureMediatRHandler
    {
        public static void RegisterHandler(IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetOrganizationHandler).Assembly));
        }
    }
}

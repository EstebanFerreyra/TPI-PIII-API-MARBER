using Services.IServices;
using Services.Services;

namespace Interface
{
    public static class CompositeRoot
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService> ();
        }
    }
}

using Project1.DAL;

namespace Project1.BL
{
    public static class Register
    {
        public static void AddService(this IServiceCollection Services)
        {
            Services.AddScoped<Interface, Service>();

        }
    }
}

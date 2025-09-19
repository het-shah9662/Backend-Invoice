using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Project1.DAL
{
    public static class Register
    {
        public static void AddRepository(this IServiceCollection Services)
        {
            Services.AddScoped<Interface, Repo>();
        }
    }
}

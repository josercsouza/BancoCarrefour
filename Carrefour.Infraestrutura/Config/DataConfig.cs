using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Carrefour.Infraestrutura.Config
{
    public static class ContextConfig
    {
        private static string _cnnStringCarrefour;

        public static string CarrefourDB => _cnnStringCarrefour ?? "";

        public static void AddContext(IConfiguration configuration)
        {
            _cnnStringCarrefour = configuration.GetConnectionString("Carrefour");
        }
    }
}

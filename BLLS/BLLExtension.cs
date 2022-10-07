using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLLS
{
    public static class BLLExtension
    {
        

        public static void AddBLLExtension( this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddDALExtension();
        }
    }
}

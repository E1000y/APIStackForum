using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntegrationTest.Fixture
{
    public class ApiWebApplicationFactory : WebApplicationFactory<APIStackForum.Startup>
    {
        private IConfiguration Configuration { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Integrations.json")
                    .Build();
                config.AddConfiguration(Configuration);
            });
        }

    }
}

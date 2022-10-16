using API.Filters;
using BLLS;
using Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIStackForum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Singleton => toute la durée de vie du serveur
            //Scoped => toute la durée de vie de la requête d'un client
            //Transient => A chaque fois que je demande le service, j'ai une nouvelle instance.

            // BLLExtension.AddBLL(services);

            services.AddBLLExtension();
            services.AddDomain();
            services.AddControllers(options => {
                options.SuppressAsyncSuffixInActionNames = false;
                options.Filters.Add(new ApiExceptionFilterAttribute());
                }).AddFluentValidation();


            //JWT Authentication
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false, //Voulez vous valider celui qui a émis le token?
                    ValidateAudience = false,
                    ValidAudience = Configuration["JwtIssuer"],
                    ValidIssuer = Configuration["JwtIssuer"],


                    ValidateIssuerSigningKey = true, // Validation de la signature du token? oui sinon le client peut modifier son token comme il veut
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
         //Retourne la différence de temps maximale autorisée entre le client et les paramètres de l'horloge du serveur.
         ClockSkew = TimeSpan.Zero // remove delay of token when expire
     };
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();

           app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

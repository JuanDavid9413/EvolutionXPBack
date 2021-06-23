using BackEnd.EvolutionXP.Business.Business;
using BackEnd.EvolutionXP.Entities.Interfaces.Business;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.EvolutionXP.Business
{
    public static class StartupBusiness
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IPlayersBusiness, PlayersBusiness>();
            services.AddTransient<IGameBusiness, GameBusiness>();
            services.AddTransient<IWarBusiness, WarBusiness>();
            services.AddTransient<IMovimientsBusiness, MovimientsBusiness>();
        }
    }
}

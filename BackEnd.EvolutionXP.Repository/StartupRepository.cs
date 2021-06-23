using BackEnd.EvolutionXP.Entities.Interfaces.Repository;
using BackEnd.EvolutionXP.Repository.Database;
using BackEnd.EvolutionXP.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.EvolutionXP.Repository
{
    public static class StartupRepository
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("currentConnection")));
            services.AddTransient<IPlayersRepository, PlayersRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IWarRepository, WarRepository>();
            services.AddTransient<IMovimientsRepository, MovimientsRepository>();
        }
    }
}

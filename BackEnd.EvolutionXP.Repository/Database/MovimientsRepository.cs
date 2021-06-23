using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Repository;
using BackEnd.EvolutionXP.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Repository.Database
{
    public class MovimientsRepository : IMovimientsRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MovimientsRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<List<Movimients>> GetAll()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                return await context.Movimients.ToListAsync();
            }
        }
    }
}

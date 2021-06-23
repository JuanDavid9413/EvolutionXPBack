using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Repository;
using BackEnd.EvolutionXP.Entities.Response;
using BackEnd.EvolutionXP.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Repository.Database
{
    public class WarRepository: IWarRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WarRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<bool> AddAsync(War war)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                context.Add(war);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }

        public async Task<List<War>> GetFilter()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                return await context.War.ToListAsync();
            }
        }

        public async Task<List<War>> GetFilter(Expression<Func<War, bool>> expression)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                return await context.War.Where(expression).Include(l => l.Game)
                                                          .Include(l => l.Players)
                                                          .Include( l => l.Movimients).ToListAsync();
            }
        }
    }
}

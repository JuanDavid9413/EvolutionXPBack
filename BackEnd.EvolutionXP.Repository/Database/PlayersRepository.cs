using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Repository;
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
    public class PlayersRepository: IPlayersRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PlayersRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<List<Players>> AddAsync(List<Players> players)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                players.ForEach(l =>
                {
                    l.Status = true;
                    l.CreateDate = DateTime.Now;
                });
                context.AddRange(players);
                await context.SaveChangesAsync();
                return players;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                Players players = new Players { Id = id };
                context.Remove(players);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }

        public async Task<List<Players>> GetAll()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                return await context.Players.ToListAsync();
            }
        }

        public async Task<List<Players>> GetFilter(Expression<Func<Players, bool>> expression)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                return await context.Players.Where(expression).ToListAsync();
            }
        }


        public async Task<bool> UpdateAsync(Players players)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                context.Update(players);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }
    }
}

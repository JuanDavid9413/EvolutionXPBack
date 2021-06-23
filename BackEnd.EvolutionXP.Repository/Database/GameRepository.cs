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

namespace BackEnd.EvolutionXP.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public GameRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<Game> AddAsync(Game game)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                game.Status = true;
                game.CreateDate = DateTime.Now;
                context.Add(game);
                await context.SaveChangesAsync();
                return game;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                Game game = new Game { Id = id };
                context.Remove(game);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }

        public async Task<List<Game>> GetAll()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                return await context.Game.ToListAsync();
            }
        }

        public async Task<List<Game>> GetFilter(Expression<Func<Game, bool>> expression)
        {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    return await context.Game.Where(expression).ToListAsync();
                }
            }

        public async Task<bool> UpdateAsync(Game game)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                context.Update(game);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }
    }
}

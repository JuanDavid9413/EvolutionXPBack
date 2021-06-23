using BackEnd.EvolutionXP.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.EvolutionXP.Repository.Database.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext( DbContextOptions<ApplicationContext> options ): base(options) { }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<War> War { get; set; }
        public virtual DbSet<Movimients> Movimients { get; set; }
    }
}

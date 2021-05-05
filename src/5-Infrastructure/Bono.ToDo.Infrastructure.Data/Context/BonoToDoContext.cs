using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Data.Extensions;
using Bono.ToDo.Data.Mappings;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Infrastructure.Utils;

namespace Bono.ToDo.Data.Context
{
    public class BonoToDoContext: DbContext
    {
        private readonly Settings settings;
        private readonly Security security;


        public BonoToDoContext(DbContextOptions<BonoToDoContext> option, Settings settings, Security security) : base(option) 
        {
            this.settings = settings;
            this.security = security;

            if (settings.IsDevelopment)
            {
                Database.Migrate();
            }
            
        }

        #region "DBSets"

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TaskToDo> TasksToDo { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData(security);

            base.OnModelCreating(modelBuilder);
        }
    }
}

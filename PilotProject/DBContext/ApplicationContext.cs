using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PilotProject.FoodMenu;
using PilotProject.Entities;
using PilotProject.Services;
using static PilotProject.Services.FilePathService;

namespace PilotProject.DBContext
{
    internal sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Drink> Drinks => Set<Drink>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();

        public ApplicationContext()
        {
            Database.EnsureCreated();   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={GetPathFile(Folder.DataBase, "dotnetpizza.db")}");
        }
    }
}
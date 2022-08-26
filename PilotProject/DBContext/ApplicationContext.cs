using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PilotProject.FoodMenu;

namespace PilotProject.DBContext
{
    internal sealed class ApplicationContext : DbContext
    {
        private string _dataBasePath = @"Data Source=D:\IT Academy Project\PilotProject\DataBase\dotnetpizza.db";

        public DbSet<User> Users => Set<User>();
        public DbSet<Drink> Drinks => Set<Drink>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();

        public ApplicationContext()
        {
            Database.EnsureCreated();   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_dataBasePath);
        }
    }
}
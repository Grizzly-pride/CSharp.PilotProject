using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PilotProject.FoodMenu;
using PilotProject.Entities;
using PilotProject.Services;


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
            optionsBuilder.UseSqlite($"Data Source={FilePathService.GetPathFile(Folder.DataBase, "dotnetpizza.db")}");
        }

        public async Task ChangeUserBalance(double changeBalance, int UserId)
        {
            string strBalance = string.Format("{0:0.0}", changeBalance).Replace(",", ".");
            string sqlExpression = $"UPDATE Users SET Balance={strBalance} WHERE Id='{UserId}'";

            using (var connection = new SqliteConnection($"Data Source={FilePathService.GetPathFile(Folder.DataBase, "dotnetpizza.db")}"))
            {
                connection.Open();

                SqliteCommand command = new(sqlExpression, connection);

                await command.ExecuteReaderAsync();
            }       
        }
    }
}
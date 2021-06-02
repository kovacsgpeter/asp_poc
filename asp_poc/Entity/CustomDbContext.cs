using System;
using asp_poc.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace asp_poc.Entity
{
    // TODO https://www.c-sharpcorner.com/article/tutorial-use-entity-framework-core-5-0-in-net-core-3-1-with-mysql-database-by2/
    public class CustomDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public CustomDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private DbSet<User> _users;

        public virtual DbSet<User> getUsers()
        {
            return _users;
        }
        
        public virtual void setUsers(DbSet<User> users)
        {
            _users = users;
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string mySqlConnectionStr = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), 
                sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 2,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        }
    }
}
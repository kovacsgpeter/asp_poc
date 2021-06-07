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

        public virtual DbSet<User> _users { get; set; }
        public virtual DbSet<Role> _roles { get; set; }
        public virtual DbSet<Address> _Addresses { get; set; }
        public virtual DbSet<UserAddress> _UserAddresses { get; set; }

        // public virtual DbSet<User> getUsers()
        // {
        //     return this._users;
        // }
        //
        // public virtual void setUsers(DbSet<User> users)
        // {
        //     this._users = users;
        // }
        

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
        
        
        protected override void OnModelCreating(ModelBuilder objModelBuilder)
        {
            
            
            objModelBuilder.Entity<Role>()
                .HasMany(c => c.Users)
                .WithOne(e => e.Role)
                .IsRequired();
            
            objModelBuilder.Entity<UserAddress>()
                .HasKey(bc => new { bc.UserId, bc.AddressId });  
            objModelBuilder.Entity<UserAddress>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserAddresses)
                .HasForeignKey(bc => bc.UserId);  
            objModelBuilder.Entity<UserAddress>()
                .HasOne(bc => bc.Address)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(bc => bc.AddressId);
          


           

            base.OnModelCreating(objModelBuilder);

        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Usado para criar as migrações
            //var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=mario1107";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=mario1107", 
                new MySqlServerVersion(new Version(8, 0, 2))
            );
            
            return new MyContext(optionsBuilder.Options);
        }
    }
}

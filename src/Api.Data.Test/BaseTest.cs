using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test;

public abstract class BaseTest
{
    public BaseTest()
    {
        
    }
}

public class DbTeste : IDisposable
{
    private string databaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", "")}";

    public ServiceProvider serviceProvider { get; private set; }

    public DbTeste()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<MyContext>( o => 
            o.UseMySql("server=localhost;port=3306;database=dbAPItest;uid=root;password=mario1107", 
                new MySqlServerVersion(new Version(8, 0, 2))),
            ServiceLifetime.Transient
        );

        serviceProvider = serviceCollection.BuildServiceProvider();
        using (var context = serviceProvider.GetService<MyContext>())
        {
            context?.Database.EnsureCreated();
        }
    }

    public void Dispose()
    {
        using (var context = serviceProvider.GetService<MyContext>())
        {
            context?.Database.EnsureDeleted();
        }
    }
}
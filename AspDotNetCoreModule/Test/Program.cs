using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using M001;
using M002;
using Microsoft.EntityFrameworkCore;
using DB_Db2;

using DB_Db1;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Test
{
    class Program
    { 

      
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // setup our DI
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddDbContext<Db1Ctx>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB_Db1"),
                b => b.MigrationsAssembly("Test")));

            serviceProvider.AddDbContext<Db2Ctx>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB_Db1"),
                b => b.MigrationsAssembly("Test")));

            serviceProvider.AddTransient<IM001, CM001>();
            serviceProvider.AddTransient<IM002, CM002>();
            var service = serviceProvider.BuildServiceProvider();

            // get data module2
            IM002 m002 = service.GetService<IM002>();
            m002.Get(new ToM002());
        }


    }
}

using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DI;
using M001;
using M002;
using DB_Db1;
using DB_Db2;
using MBase;

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
            serviceProvider.AddTransient<IM010, CM010>();
            serviceProvider.AddTransient<IM011, CM011>();

            var service = serviceProvider.BuildServiceProvider();

            // get data module2
            IM002 m002 = service.GetService<IM002>();
            m002.Get(new ToM002());
        }
    }
}

using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using M001;
using M002;
using Microsoft.EntityFrameworkCore;
using DB_Db2;

namespace Test
{
    class Program
    { 

      
        static void Main(string[] args)
        {
            // setup our DI
            var serviceProvider = new ServiceCollection();

            // .AddTransient<IM001, CM001>()
            // .AddTransient<IM002, CM002>()
            // .BuildServiceProvider();


            //serviceProvider.AddDbContext<Db2Ctx>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DB_Db2"),
            //    b => b.MigrationsAssembly("AspDotNetCoreWeb")));

            serviceProvider.AddTransient<IM001, CM001>();
            serviceProvider.AddTransient<IM002, CM002>();
            var service = serviceProvider.BuildServiceProvider();

            // get data module2
            IM002 m002 = service.GetService<IM002>();
            m002.Get(new ToM002());
        }


    }
}

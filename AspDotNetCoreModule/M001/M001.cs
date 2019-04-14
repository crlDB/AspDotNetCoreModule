using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using DB_Db2;
using DB_Db1;

namespace M001
{
    public class CM001 : IM001
    {
        private IServiceProvider _serviceProvider;


        public CM001(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;



        }

        public FromM001 Get(ToM001 toM001)
        {
            // add records
            var scope = _serviceProvider.CreateScope();

            var db1 = scope.ServiceProvider.GetService<Db1Ctx>(); //scoped
            db1 = scope.ServiceProvider.GetService<Db1Ctx>(); //scoped
            db1 = scope.ServiceProvider.GetService<Db1Ctx>(); //scoped
            db1 = scope.ServiceProvider.GetService<Db1Ctx>(); //scoped

            var t = new DB_Db1.Table1 { Num1 = 1, String1 = $"MOD1" };
            db1.Table1.Add(t);
            db1.SaveChanges();

            var db2 = scope.ServiceProvider.GetService<Db2Ctx>();

            var x = new DB_Db2.Table1 { Num1 = 101, String1 = $"MOD101" };
            db2.Table1.Add(x);
            db2.SaveChanges();

            var m011 = _serviceProvider.GetService<IM011>();
            m011.Get(new ToM011());

            return new FromM001 { Nbr1 = 10 };

        }


    }
}

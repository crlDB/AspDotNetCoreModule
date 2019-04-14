using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using DB_Db2;

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
            var dbx = scope.ServiceProvider.GetService<Db2Ctx>();

            Table1 t = new Table1 { Num1 = 1, String1 = $"MOD1" };
            dbx.Table1.Add(t);
            dbx.SaveChanges();

            var m011 = _serviceProvider.GetService<IM011>();
            m011.Get(new ToM011());

            return new FromM001 { Nbr1 = 10 };

        }


    }
}

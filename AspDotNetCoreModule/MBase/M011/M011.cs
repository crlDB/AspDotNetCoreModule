using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using DB_Db2;

namespace MBase
{
    public class CM011 : IM011
    {
        private IServiceProvider _serviceProvider;
 

        public CM011(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;



        }

      
        public FromM011 Get(ToM011 toM011)
        {
            // add records
            var scope = _serviceProvider.CreateScope();
            var dbx = scope.ServiceProvider.GetService<Db2Ctx>();

            Table1 t = new Table1 { Num1 = 11, String1 = $"MOD11" };
            dbx.Table1.Add(t);
            dbx.SaveChanges();

            return new FromM011 { Nbr1 = 10 };
        }
    }
}

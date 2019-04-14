using DI;
using System;
using Microsoft.Extensions.DependencyInjection;
using DB_Db2;

namespace MBase
{
    public class CM010 : IM010
    {
        private IServiceProvider _serviceProvider;
 

        public CM010(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;



        }

      
        public FromM010 Get(ToM010 toM010)
        {
            // add records
            var scope = _serviceProvider.CreateScope();
            var dbx = scope.ServiceProvider.GetService<Db2Ctx>();

            Table1 t = new Table1 { Num1 = 10, String1 = $"MOD10" };
            dbx.Table1.Add(t);
            dbx.SaveChanges();

            var m001 = _serviceProvider.GetService<IM001>();
            m001.Get(new ToM001());

            var m002 = _serviceProvider.GetService<IM002>();
            m002.Get(new ToM002());








            return new FromM010 { Nbr1 = 10 };
        }
    }
}

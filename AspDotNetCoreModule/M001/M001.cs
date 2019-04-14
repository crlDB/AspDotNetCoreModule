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

            for (int i = 0; i < 100; i++)
            {
                Table1 t = new Table1 { Num1 = i, String1 = $"{i}" };
                dbx.Table1.Add(t);
                dbx.SaveChanges();

            }


            // get data module2
            //IM002 m002 = _serviceProvider.GetService<IM002>();
            //m002.Get(new ToM002());
            //var fromM002 = m002.Get(new ToM002 { Nbr1 = 100 });



            return new FromM001 { Nbr1 = 10 };

        }

      
    }
}

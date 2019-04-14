using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_CFG
{
    class Db1Ctx : DbContext
    {

        public Db1Ctx(DbContextOptions<Db1Ctx> options)
        : base(options)
        {
            
        }

        public DbSet<Table1> Table1 { get; set; }


    }
}

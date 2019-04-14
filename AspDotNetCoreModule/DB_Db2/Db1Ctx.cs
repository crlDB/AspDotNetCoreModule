using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Db2
{
    public class Db2Ctx : DbContext
    {
        public Db2Ctx(DbContextOptions<Db2Ctx> options)
        : base(options)
        {
        }

        public DbSet<Table1> Table1 { get; set; }
        public DbSet<Table2> Table2 { get; set; }

    }
}

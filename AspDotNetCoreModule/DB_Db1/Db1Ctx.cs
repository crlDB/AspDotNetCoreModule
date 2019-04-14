using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Db1
{
    /// <summary>
    /// dotnet ef migrations add MXXX -c Db1Ctx
    /// dotnet ef database update -c Db1Ctx
    /// 
    /// 
    /// </summary>

    public class Db1Ctx : DbContext
    {
        public Db1Ctx(DbContextOptions<Db1Ctx> options)
        : base(options)
        {
        }

        public DbSet<Table1> Table1 { get; set; }
        public DbSet<Table2> Table2 { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB_CFG
{
    public class Table1
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string String1 { get; set; }
        public int Num1 { get; set; }

    }
}

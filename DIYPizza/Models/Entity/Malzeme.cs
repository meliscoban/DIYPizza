using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIYPizza.Models.Entity
{
    public class Malzeme
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Ad { get; set; }
    }
}

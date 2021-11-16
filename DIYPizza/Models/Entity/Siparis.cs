using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIYPizza.Models.Entity
{
    public class Siparis
    {
        public int Id { get; set; }

        public DateTime Zaman { get; set; } = DateTime.Now;

        [Required, MaxLength(400)]
        public string Adres { get; set; }

        public ICollection<Malzeme> Malzemeler { get; set; }
    }
}

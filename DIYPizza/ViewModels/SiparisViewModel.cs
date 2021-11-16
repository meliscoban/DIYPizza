using DIYPizza.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIYPizza.ViewModels
{
    public class SiparisViewModel
    {
        public List<Secim> Secimler { get; set; }

        [Required(ErrorMessage = "Adres alanı zorunludur."), MaxLength(400)]
        public string Adres { get; set; }
    }
}

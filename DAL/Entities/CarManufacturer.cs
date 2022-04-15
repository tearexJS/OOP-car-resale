using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record CarManufacturer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public List<CarModel> Models { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public decimal Mileage { get; set; }
        public int ManufacturingYear { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Car
    {
        public int CarId { get; set; }
        public decimal Mileage { get; set; }
        public int ManufacturingYear { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}

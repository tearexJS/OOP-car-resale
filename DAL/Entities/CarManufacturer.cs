using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CarManufacturer
    {
        public int CarManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public List<CarModel> Models { get; set; }
    }
}

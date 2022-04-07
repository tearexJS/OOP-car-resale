using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CarModel
    {
        public int CarModelId { get; set; }
        public string ModelName { get; set; }
        public decimal Engine { get; set; }
        public decimal Power { get; set; }
        public int Seats { get; set; }
        public decimal TrunkSize { get; set; }
        public List<Car> Cars { get; set; }
    }
}

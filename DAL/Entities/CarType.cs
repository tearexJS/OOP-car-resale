using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CarType
    {
        public int CarTypeId { get; set; }

        public string Type { get; set; }

        public List<CarModel> Models { get; set; }
    }
}

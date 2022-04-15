using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarModelId { get; set; }
        public string ModelName { get; set; }
        public decimal Engine { get; set; }
        public decimal Power { get; set; }
        public int Seats { get; set; }
        public decimal TrunkSize { get; set; }
        public List<Car> Cars { get; set; }
    }
}

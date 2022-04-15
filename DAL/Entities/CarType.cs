using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public record CarType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarTypeId { get; set; }

        public string Type { get; set; }

        public List<CarModel> Models { get; set; }
    }
}

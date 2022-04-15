using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Advertisement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdvertisementId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationTime { get; set; }
        public List<Image> Images { get; set; }
    }
}

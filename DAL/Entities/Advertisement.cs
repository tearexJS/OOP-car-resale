using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Advertisement
    {
        public int AdvertisementId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationTime { get; set; }
        public List<Image> Images { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationOasis.Core.Dtos.HotelDtos
{
    public class HotelModelDTO
    {
        public int HotelImageId { get; set; }
        public string HotelImageName { get; set; }
        public string HotelImage { get; set; }
        public decimal HotelImagePrice { get; set; }
        public string HotelImageCategory { get; set; }
        public string HotelImageLocation { get; set; }
        public bool IsPopular { get; set; }
        public string HotelImageStyle { get; set; }
        public string HotelImageStyle1 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationOasis.Core.Dtos.HotelDtos
{
    public class HotelDetailsDTO
    {
        public int HotelImageId { get; set; }
        public string HotelImageName { get; set; }
        public string HotelImage { get; set; }
        public decimal HotelImagePrice { get; set; }
        public string HotelDescription { get; set; }
        public string HotelImageLocation { get; set; }
        public string HotelImageStyle { get; set; }
        public string HotelImageStyle1 { get; set; }
        public int HotelDetailBedRoomNum { get; set; }
        public int HotelDetailLivingRoomNum { get; set; }
        public int HotelDetailbathRoomNum { get; set; }
        public int HotelDetailDinninRoomNum { get; set; }
        public int HotelDetailMPS { get; set; }
        public int HotelDetailUnitReady { get; set; }
        public int HotelDetailRefrigiratorNum { get; set; }
        public int HotelDetailTelevisionNum { get; set; }
    }
}

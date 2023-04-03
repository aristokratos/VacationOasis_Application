using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Core.Dtos.HotelDtos;

namespace VacationOasis.Core.Interface
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelModelDTO>> GetAllHotel();
        Task<HotelModelDTO> GetHotelById(int id);
        Task<HotelDetailsDTO> Details(int id);
    }
}

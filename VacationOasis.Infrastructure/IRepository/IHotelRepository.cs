using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;

namespace VacationOasis.Infrastructure.IRepository
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotel();
        Task<Hotel> GetHotelById(int id);
        Task<List<string[]>> GetAllImageUrl();
        Task<string[]> GetImageById(string HouseId);
    }
}

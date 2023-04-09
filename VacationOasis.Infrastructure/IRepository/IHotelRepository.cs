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
        Task<List<string[]>> GetImageUrlByIdAsync();
        Task<string[]> GetImageById(string HouseId);
       // Task<string[]> GetImageById(int HouseId);
    }
}

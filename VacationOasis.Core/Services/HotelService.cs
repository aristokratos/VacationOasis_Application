using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Core.Dtos.HotelDtos;
using VacationOasis.Core.Interface;
using VacationOasis.Infrastructure.IRepository;

namespace VacationOasis.Core.Services
{
    public class HotelService:IHotelService
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IMapper mapper;
        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<HotelModelDTO>> GetAllHotel()
        {
            var AllHotel = await hotelRepository.GetAllHotel();
            return mapper.Map<IEnumerable<HotelModelDTO>>(AllHotel);
        }
        public async Task<HotelModelDTO> GetHotelById(int id)
        {
            var hotelByid = await hotelRepository.GetHotelById(id);
            if (hotelByid == null)
            {
                throw new ArgumentException(nameof(hotelByid));
            }
            return mapper.Map<HotelModelDTO>(hotelByid);
        }
        public async Task<HotelDetailsDTO> Details(int id)
        {
            try
            {
                var hotelDetails = await hotelRepository.GetHotelById(id);
                if (hotelDetails == null)
                {
                    throw new ArgumentException(nameof(hotelDetails));
                }
                return mapper.Map<HotelDetailsDTO>(hotelDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


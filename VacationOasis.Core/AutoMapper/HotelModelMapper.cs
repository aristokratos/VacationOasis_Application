using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Core.Dtos.HotelDtos;
using VacationOasis.Domain.Models;
using AutoMapper;

namespace VacationOasis.Core.AutoMapper
{
    public class HotelModelMapper: Profile
    {
        public HotelModelMapper()
        {
            
            CreateMap<Hotel, HotelModelDTO>().ReverseMap();
            CreateMap<Hotel, HotelDetailsDTO>().ReverseMap();
            
        }
    }
}

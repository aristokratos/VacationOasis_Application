using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;

namespace VacationOasis.Infrastructure.Repository
{
    public class HotelRepository
    {
        public class MyHotelRepository
        {
            private readonly IConfiguration _configuration;
            private readonly string _connectionString;

            public MyHotelRepository(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionString = _configuration.GetConnectionString("DefaultConnection");
            }

            public async Task<List<Hotel>> GetAllHotelsAsync()
            {
                List<Hotel> hotelList = new List<Hotel>();
                try
                {
                    using SqlConnection connection = new SqlConnection(_connectionString);
                    using SqlCommand command = new SqlCommand("dbo.spGetAllHotels", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    await connection.OpenAsync();
                    using SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Hotel Hotel = new Hotel
                        {
                            HotelImageId = reader.GetInt32(reader.GetOrdinal("HouseId")),
                            HotelImageName = reader.GetString(reader.GetOrdinal("HouseName")),
                            HotelImagePrice = reader.GetDecimal(reader.GetOrdinal("HousePrice")),
                            HotelImage = reader.GetString(reader.GetOrdinal("ImageUrl")),
                            HotelDetailbathRoomNum = reader.GetInt32(reader.GetOrdinal("HouseBathRoom")),
                            HotelDetailDinninRoomNum = reader.GetInt32(reader.GetOrdinal("HouseDiningRoom")),
                            HotelDetailBedRoomNum = reader.GetInt32(reader.GetOrdinal("HouseBedRoom")),
                            HotelDetailLivingRoomNum = reader.GetInt32(reader.GetOrdinal("HouseLivingRoom")),
                            HotelDetailMPS = reader.GetInt32(reader.GetOrdinal("HouseMPS")),
                            HotelDetailRefrigiratorNum = reader.GetInt32(reader.GetOrdinal("HouseRefrigirator")),
                            HotelDetailTelevisionNum = reader.GetInt32(reader.GetOrdinal("HouseTelevision")),
                            HotelDetailUnitReady = reader.GetInt32(reader.GetOrdinal("HouseUnitReady")),
                            HotelImageCategory = reader.GetString(reader.GetOrdinal("CategoryName")),
                            HotelImageLocation = reader.GetString(reader.GetOrdinal("HouseLocation")),
                            HotelImageStyle = reader.GetString(reader.GetOrdinal("HouseStyle")),
                            HotelImageStyle1 = reader.GetString(reader.GetOrdinal("HouseStyle1")),
                            IsPopular = reader.GetBoolean(reader.GetOrdinal("IsPopular")),
                        };
                        hotelList.Add(Hotel);
                    }
                    return hotelList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting hotels", ex);
                }
            }

            public async Task<Hotel> GetHotelByIdAsync(int HotelId)
            {
                var allHotels = await GetAllHotelsAsync();
                return allHotels.FirstOrDefault(x => x.HotelImageId == HotelId);
            }

            public async Task<List<string[]>> GetAllImageUrlsAsync()
            {
                var imageList = new List<string[]>();
                try
                {
                    using SqlConnection connection = new SqlConnection(_connectionString);
                    using SqlCommand command = new SqlCommand("dbo.spGetAllImage", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    await connection.OpenAsync();
                    using SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var imageArray = new string[2];
                        imageArray[0] = reader.GetString(reader.GetOrdinal("ImageUrl"));
                        imageArray[1] = reader.GetInt32(reader.GetOrdinal("HouseId")).ToString();
                        imageList.Add(imageArray);
                    }
                    return imageList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting image URLs", ex);
                }
            }


            public async Task<string?> GetImageUrlByIdAsync(string houseId)
            {
                var allImageUrls = await GetAllImageUrlsAsync();

                foreach (var imageUrl in allImageUrls)
                {
                    if (imageUrl[1] == houseId)
                    {
                        return imageUrl[0];
                    }
                }

                return null;
            }
        }
    }
}
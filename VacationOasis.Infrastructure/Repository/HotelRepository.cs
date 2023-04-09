using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;
using Newtonsoft.Json;
using VacationOasis.Infrastructure.IRepository;

namespace VacationOasis.Infrastructure.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public HotelRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("VacationOasisConnectionString");
        }

        public async Task<List<Hotel>> GetAllHotel()
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

        public async Task<Hotel> GetHotelById(int id)
        {
            var allHotels = await GetAllHotel();
            return allHotels.FirstOrDefault(x => x.HotelImageId == id);
        }

        public async Task<List<string[]>> GetImageUrlByIdAsync()
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

        public async Task<string[]> GetImageById(string HouseId)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand command = new SqlCommand("dbo.spGetImageById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@HouseId", HouseId);
                await connection.OpenAsync();
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    string[] imageArray = new string[2];
                    imageArray[0] = reader.GetString(reader.GetOrdinal("ImageUrl"));
                    imageArray[1] = reader.GetInt32(reader.GetOrdinal("HouseId")).ToString();
                    return imageArray;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting image for house with ID: {HouseId}", ex);
            }
        }

        public async Task<List<Hotel>> SearchHotel(string searchString)
        {
            List<Hotel> hotelList = new List<Hotel>();
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand command = new SqlCommand("dbo.spSearchHotels", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@SearchString", searchString);
                await connection.OpenAsync();
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Hotel hotel = new Hotel
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
                    //var json = JsonSerializer.Serialize(hotelList);
                    //File.WriteAllText("hotels.json", json);
                    hotelList.Add(hotel);
                }
                return hotelList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching hotels with query: {searchString}", ex);
            }
        }
    }
}



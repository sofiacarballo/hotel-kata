using System;
using System.Diagnostics.CodeAnalysis;
using HotelKata.Repositories;

namespace HotelKata.Services
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository HotelRepository;
        private readonly IAvailabilityService AvailabilityService;
        public HotelService(IHotelRepository hotelRepository, IAvailabilityService availabilityService)
        {
            HotelRepository = hotelRepository;
            AvailabilityService = availabilityService;
        }

        public void AddHotel(Hotel hotel)
        {
            HotelRepository.Add(hotel);
        }
    
        public void SetRoom(int hotelId, int numberOfRooms, RoomType roomType)
        {
            AvailabilityService.AddRoomAvailability(hotelId, numberOfRooms, roomType);
        }
            
        public Hotel FindHotelBy(int hotelId) => HotelRepository.GetById(hotelId);
    }
}
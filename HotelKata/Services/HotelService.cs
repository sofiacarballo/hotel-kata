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
            var roomAvailability = new Availability(hotelId, numberOfRooms, roomType);
            AvailabilityService.AddRoomAvailability(roomAvailability);
        }
            
        public HotelAvailability FindHotelBy(int hotelId)
        {
            var hotel = HotelRepository.GetById(hotelId);
            
            return AvailabilityService.GetAvailability(hotel);
        }
    }
}
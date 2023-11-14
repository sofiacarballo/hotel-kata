using System;

namespace HotelKata.Services
{
    public class HotelService : IHotelService
    {
        private IHotelRepository HotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            HotelRepository = hotelRepository;
        }

        public void AddHotel(Hotel hotel)
        {
            HotelRepository.Add(hotel);
        }
    
        public void SetRoom(int hotelId, int number, RoomType roomType)
        {
            throw new NotImplementedException();
        }
            
        public Hotel FindHotelBy(int hotelId) => HotelRepository.GetById(hotelId);
    }
}
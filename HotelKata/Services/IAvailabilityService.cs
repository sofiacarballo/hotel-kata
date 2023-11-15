namespace HotelKata.Services
{
     public interface IAvailabilityService
    {
        void AddRoomAvailability(int hotelId, int numberOfRooms, RoomType roomType);
    }
}
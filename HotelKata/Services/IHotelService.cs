namespace HotelKata.Services
{
    public interface IHotelService
    {
        void AddHotel(Hotel hotel);
        void SetRoom(int hotelId, int number, RoomType roomType);
        Hotel FindHotelBy(int hotelId);
    }
}
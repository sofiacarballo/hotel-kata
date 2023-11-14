namespace HotelKata
{
    public interface IHotelRepository
    {
        void Add(Hotel hotel);
        Hotel GetById(int id);
    }
}
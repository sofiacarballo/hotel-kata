using System.Collections.Generic;

namespace HotelKata.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public List<Hotel> Hotels = new List<Hotel>();
        public void Add(Hotel hotel)
        {
            Hotels.Add(hotel);
        }

        public Hotel GetById(int id) => Hotels.Find(hotel => hotel.Id.Equals(id));
    }
}
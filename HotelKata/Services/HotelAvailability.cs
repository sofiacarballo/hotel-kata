using System;

namespace HotelKata.Services
{
    public class HotelAvailability : IEquatable<HotelAvailability>
    {
        private readonly Hotel hotel;

        public HotelAvailability(Hotel hotel)
        {
            this.hotel = hotel;
        }

        public string Print()
        {
            return ""; // acá se devolvería a si mismo
        }

        public bool Equals(HotelAvailability other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(hotel, other.hotel);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HotelAvailability)obj);
        }

        public override int GetHashCode()
        {
            return (hotel != null ? hotel.GetHashCode() : 0);
        }
    }
}
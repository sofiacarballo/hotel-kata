using System;
using System.Diagnostics.CodeAnalysis;

namespace HotelKata
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Availability : IEquatable<Availability>
    {
        private readonly int hotelId;
        private readonly int numberOfRooms;
        private readonly RoomType roomType;

        public Availability(int hotelId, int numberOfRooms, RoomType roomType)
        {
            this.hotelId = hotelId;
            this.numberOfRooms = numberOfRooms;
            this.roomType = roomType;
        }

        public bool Equals(Availability other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return hotelId == other.hotelId && numberOfRooms == other.numberOfRooms && roomType == other.roomType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Availability)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = hotelId;
                hashCode = (hashCode * 397) ^ numberOfRooms;
                hashCode = (hashCode * 397) ^ (int)roomType;
                return hashCode;
            }
        }
    }
}
namespace HotelKata.Services
{
     public interface IAvailabilityService
    {
        void AddRoomAvailability(Availability roomAvailability);
        HotelAvailability GetAvailability(Hotel hotel);
    }
}
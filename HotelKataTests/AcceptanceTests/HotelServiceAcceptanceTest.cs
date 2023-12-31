﻿using HotelKata;
using HotelKata.Repositories;
using HotelKata.Services;
using NUnit.Framework;

namespace HotelKataTests.AcceptanceTests
{
    [TestFixture]
    public class HotelServiceAcceptanceTest
    {
        [Test]
        public void DisplayHotelInformation()
        {
            const string hotelAvailability = @"
                +------------+-----------+
                | Hotel: Chacana Out     |
                +------------+-----------+
                | Room       | Quantity  |
                +------------+-----------+
                | Standard   | 5         |
                | Double     | 10        |
                | Familiar   | 2         |
                +------------+-----------+
                ";
            
            const int hotelId = 1;
            
            var hotel = new Hotel(hotelId, "Chacana Out");
            IHotelRepository hotelRepository = new HotelRepository();
            IAvailabilityService hotelAvailabilityService = new AvailabilityService();
            
            var hotelService = new HotelService(hotelRepository, hotelAvailabilityService);
            
            hotelService.AddHotel(hotel);
            hotelService.SetRoom(hotelId, 5, RoomType.Standard);
            hotelService.SetRoom(hotelId, 10, RoomType.Double);
            hotelService.SetRoom(hotelId, 2, RoomType.Familiar);

            var expectedHotel = hotelService.FindHotelBy(hotelId);
            var result = expectedHotel.Print();

            Assert.Equals(result, hotelAvailability);
        }
    }
}
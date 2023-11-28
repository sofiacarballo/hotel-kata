using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HotelKata;
using HotelKata.Repositories;
using NUnit.Framework;

namespace HotelKataTests.Repositories
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HotelRepositoryShould
    {
        private HotelRepository hotelRepository;
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel(1, "Chacana Out");
            hotelRepository = new HotelRepository();
            hotelRepository.Add(hotel);
        }
        
        [Test]
        public void AddHotel()
        {
            var expectedHotels = new List<Hotel> { hotel };
            
            Assert.AreEqual(hotelRepository.Hotels, expectedHotels);
        }

        [Test]
        public void GetById()
        {
            var expectedHotel = hotelRepository.GetById(1);
            
            Assert.AreEqual(expectedHotel, hotel);
        }
    }
}
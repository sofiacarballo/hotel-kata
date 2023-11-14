using System.Diagnostics.CodeAnalysis;
using HotelKata;
using HotelKata.Services;
using Moq;
using NUnit.Framework;

namespace HotelKataTests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HotelServiceShould
    {
        private Hotel hotel;
        private Mock<IHotelRepository> mockHotelRepository;
        private HotelService hotelService;
        private const int HotelId = 1;
        
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel(HotelId, "Chacana Out");
            mockHotelRepository = new Mock<IHotelRepository>();         
            hotelService = new HotelService(mockHotelRepository.Object);
        }
        
        [Test]
        public void AddHotel()
        {
            hotelService.AddHotel(hotel);

            mockHotelRepository.Verify(hotelRepository => hotelRepository.Add(hotel), Times.Once);
        }

        [Test]
        public void FindHotelById()
        {
            mockHotelRepository.Setup(repository => repository.GetById(HotelId)).Returns(hotel);

            var result = hotelService.FindHotelBy(HotelId);
            
            mockHotelRepository.Verify(hotelRepository => hotelRepository.GetById(HotelId), Times.Once);
            Assert.AreEqual(result, hotel);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using HotelKata;
using HotelKata.Exceptions;
using HotelKata.Repositories;
using HotelKata.Services;
using Moq;
using NUnit.Framework;

namespace HotelKataTests.Services
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HotelServiceShould
    {
        private Hotel hotel;
        private Mock<IHotelRepository> mockedHotelRepository;
        private Mock<IAvailabilityService> mockedAvailabilityService;
        private IAvailabilityService availabilityService;
        private HotelService hotelService;
        private const int HotelId = 1;
        
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel(HotelId, "Chacana Out");
            availabilityService = new AvailabilityService();
            mockedHotelRepository = new Mock<IHotelRepository>();
            mockedAvailabilityService = new Mock<IAvailabilityService>();  
            hotelService = new HotelService(mockedHotelRepository.Object, mockedAvailabilityService.Object);
        }
        
        [Test]
        public void AddHotel()
        {
            hotelService.AddHotel(hotel);

            mockedHotelRepository.Verify(hotelRepository => hotelRepository.Add(hotel), Times.Once);
        }

        [Test]
        public void FindHotelById()
        {
            var hotelAvailability = new HotelAvailability(hotel);
            
            mockedHotelRepository.Setup(repository => repository.GetById(HotelId)).Returns(hotel);
            mockedAvailabilityService.Setup(availabilityService =>
                availabilityService.GetAvailability(hotel)).Returns(hotelAvailability);

            var expectedHotel = hotelService.FindHotelBy(HotelId);

            mockedHotelRepository.Verify(hotelRepository => hotelRepository.GetById(HotelId), Times.Once);
            mockedAvailabilityService.Verify(availabilityService => availabilityService.GetAvailability(hotel), Times.Once);
            Assert.AreEqual(expectedHotel, hotelAvailability);
        }

        [Test]
        public void ReturnHotelAndAvailability()
        {
            var hotelAvailability = new HotelAvailability(hotel);

            mockedAvailabilityService.Setup(x => x.GetAvailability(hotel)).Returns(hotelAvailability);
        }

        [Test]
        public void ReturnExceptionWhenHotelIsNotFound()
        {
            mockedHotelRepository.Setup(repository => repository.GetById(HotelId)).Throws(new HotelNotFoundException());

            Assert.Throws<HotelNotFoundException>(() => hotelService.FindHotelBy(HotelId));
        }

        [Test]
        public void SetRoom()
        {
            const int numberOfRooms = 5;
            
            hotelService.SetRoom(HotelId, numberOfRooms, RoomType.Standard);
            var expectedAvailability = new Availability(HotelId, numberOfRooms, RoomType.Standard);

            mockedAvailabilityService.Verify(availabilityService => availabilityService.AddRoomAvailability(expectedAvailability), Times.Once);
        }
    }
}
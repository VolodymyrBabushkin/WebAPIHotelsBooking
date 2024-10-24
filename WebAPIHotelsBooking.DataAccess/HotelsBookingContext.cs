using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess
{
    public  class HotelsBookingContext
    {
        public ICollection<ClientEntity> Clients { get; }
        public ICollection<HotelEntity> Hotels { get; }
        public ICollection<ReservationEntity> Reservations { get; }
        public ICollection<RoomEntity> Rooms { get; }

        public HotelsBookingContext()
        {
            Clients = new List<ClientEntity>()
            {
                new ClientEntity
                {
                    Id = "1",
                    FirstName = "Axel",
                    LastName = "Van de Velde",
                },
                new ClientEntity
                {
                    Id = "2",
                    FirstName = "Gordan",
                    LastName = "Laydel",
                },
                new ClientEntity
                {
                    Id = "3",
                    FirstName = "Janie",
                    LastName = "Whittam",
                },
                new ClientEntity
                {
                    Id = "4",
                    FirstName = "Lilas",
                    LastName = "Simko",
                },
                new ClientEntity
                {
                    Id = "5",
                    FirstName = "Toby",
                    LastName = "Peltzer",
                },
            };

            Hotels = new List<HotelEntity>()
            {
                new HotelEntity
                {
                    Id = "1",
                    Name = "Nature Link Resort",
                    Rating = 9.8f,
                    Country = "USA",
                    City = "Nisswa",
                    Address = "24621 S Clark Lake Rd, Nisswa, MN, 56468",
                },
                new HotelEntity
                {
                    Id = "2",
                    Name = "Grand Elysee Hamburg",
                    Rating = 9.4f,
                    Country = "Germany",
                    City = "Hamburg",
                    Address = "Rothenbaumchaussee 10, Hamburg, HH, 20148",
                },
                new HotelEntity
                {
                    Id = "3",
                    Name = "Radisson Blu Hotel, Kyiv Podil City Centre",
                    Rating = 9.0f,
                    Country = "Ukraine",
                    City = "Kyiv",
                    Address = "17-19 Bratskaya Street, Kyiv, 4070",
                },
            };

            Rooms = new List<RoomEntity>()
            {
                new RoomEntity
                {
                    Id = "1",
                    HotelId = "1",
                    RoomNumber = 47,
                    BedsCount = 2,
                    FreeWiFi = true,
                },
                new RoomEntity
                {
                    Id = "2",
                    HotelId = "1",
                    RoomNumber = 58,
                    BedsCount = 1,
                    FreeWiFi = true,
                },
                new RoomEntity
                {
                    Id = "3",
                    HotelId = "2",
                    RoomNumber = 12,
                    BedsCount = 1,
                    FreeWiFi = false,
                },
                new RoomEntity
                {
                    Id = "4",
                    HotelId = "2",
                    RoomNumber = 33,
                    BedsCount = 2,
                    FreeWiFi = true,
                },
                new RoomEntity
                {
                    Id = "5",
                    HotelId = "3",
                    RoomNumber = 51,
                    BedsCount = 2,
                    FreeWiFi = true,
                },
                new RoomEntity
                {
                    Id = "6",
                    HotelId = "3",
                    RoomNumber = 60,
                    BedsCount = 1,
                    FreeWiFi = true,
                },
            };

            Reservations = new List<ReservationEntity>()
            {
                new ReservationEntity
                {
                    Id = "1",
                    ClientId = "1",
                    RoomId = "1",
                    Begin = "2024-10-20",
                    End = "2024-10-24",
                },
                new ReservationEntity
                {
                    Id = "2",
                    ClientId = "2",
                    RoomId = "3",
                    Begin = "2024-10-5",
                    End = "2024-11-6",
                },
                new ReservationEntity
                {
                    Id = "3",
                    ClientId = "3",
                    RoomId = "2",
                    Begin = "2024-9-10",
                    End = "2024-9-15",
                },
                new ReservationEntity
                {
                    Id = "4",
                    ClientId = "4",
                    RoomId = "4",
                    Begin = "2023-2-23",
                    End = "2023-3-5",
                },
                new ReservationEntity
                {
                    Id = "5",
                    ClientId = "5",
                    RoomId = "5",
                    Begin = "2024-2-8",
                    End = "2024-2-15",
                },
            };
        }
    }
}

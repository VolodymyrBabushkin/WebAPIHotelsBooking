namespace PSVHotelsService
{
    public class PSVHotels : IPSVHotels
    {
        public IEnumerable<PSVHotelModel> GetHotels()
        {
            return new List<PSVHotelModel>()
            {
                new PSVHotelModel
                {
                    Id = "100",
                    Name = "Sunny Nebula",
                    Rating = 7.5f,
                    LongAddress = "USA | Jersey | 312 Ege Ave",
                },
                new PSVHotelModel
                {
                    Id = "101",
                    Name = "White Cave",
                    Rating = 8f,
                    LongAddress = "USA | Griffith | 825 N Glenwood Ave",
                },
            };
        }
    }
}

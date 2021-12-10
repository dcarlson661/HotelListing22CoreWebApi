namespace HotelListing22CoreWebApi.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Country))]
        public Country Country { get; set; }
        public int CountryId { get; set; }

    }
}

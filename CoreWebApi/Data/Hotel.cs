namespace HotelListing22CoreWebApi.Data
{
    public class Hotel //MapperInitializer.cs will use mapper to map to the cooresponding DTO
    {                  // HotelDTO.cs will inherit fields from CreateHotelDTO for all the fields mapper needs
                       // the HotelController.cs where the actions like "get" are coded
                       //   will further use UnitOfWork.cs 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Country))]   
        public int CountryId { get; set; } //must come first
        public Country Country { get; set; }
    }
}

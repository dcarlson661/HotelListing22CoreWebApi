using System.ComponentModel.DataAnnotations;

namespace HotelListing22CoreWebApi.Models
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hotel Name Is Too Long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Address Name Is Too Long")]
        public string Address { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

    public class HotelDTO : CreateHotelDTO //inherit from CreateHotelDTO to get the properties of CreateHotelDTO
    {
        //there are no functions coded here just properties (fields) name,address...Id and Country
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}

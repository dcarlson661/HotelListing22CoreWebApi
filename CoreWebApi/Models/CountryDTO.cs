using System.ComponentModel.DataAnnotations;

namespace HotelListing22CoreWebApi.Models
{

    public class CreateCountryDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name Is Too Long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Short Country Name Is Too Long")]
        public string ShortName { get; set; }
    }

    /// <summary>
    /// CountryDTO gets Id and Hotels and because it inherits from CreateCountryDTO
    ///    it gets Name and Shortname.  b/c Create doesn't need the Id because Id is database generated
    ///    but to get the Hotels for a specific country you'll need the country Id for the lookup
    ///    
    /// Remember DTOs speak to other DTOs to
    /// </summary>
    public class CountryDTO : CreateCountryDTO 
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }
}

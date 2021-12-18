using AutoMapper;
using HotelListing22CoreWebApi.IRepository;
using HotelListing22CoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing22CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, 
                                 ILogger<CountryController> logger,
                                 IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger     = logger;
            _mapper     = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results    = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Err GetContries {nameof(GetCountries)}");
                return StatusCode(500, "GetCountries Internal Server Error.");
            }
        }

    }
}

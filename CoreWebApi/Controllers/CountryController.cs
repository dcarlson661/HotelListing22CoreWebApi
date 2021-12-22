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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries  = await _unitOfWork.Countries.GetAll();
                var results    = _mapper.Map<IList<CountryDTO>>(countries);
                return           Ok(results);   
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, $"Err GetContries {nameof(GetCountries)}");
                return StatusCode(500, "GetCountries Internal Server Error.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                //in genericrepository i have the signature for the get
                //  async Task<T> IGenericRepository<T>.Get(Expression<Func<T, bool>> expression, List<string> includes)
                //
                //and that get expects an Expression (q => q.Id == id)
                //     and a list of strings to be added to the query new List<string> {"Hotels"}
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> {"Hotels"});
                var result   = _mapper.Map<CountryDTO>(country);
                return          Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, $"Err GetContry {nameof(GetCountry)}");
                return StatusCode(500, "GetCountries Internal Server Error.");
            }
        }

    }
}

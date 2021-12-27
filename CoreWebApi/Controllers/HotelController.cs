using AutoMapper;
using HotelListing22CoreWebApi.IRepository;
using HotelListing22CoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing22CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork                _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper                    _mapper;

        public HotelController(IUnitOfWork unitOfWork,
                               ILogger<CountryController> logger,
                               IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels  = await _unitOfWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(hotels);
                return        Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, $"Err GetHotels {nameof(GetHotels)}");
                return StatusCode(500, "GetHotels Internal Server Error.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                //in genericrepository i have the signature for the get
                //  async Task<T> IGenericRepository<T>.Get(Expression<Func<T, bool>> expression, List<string> includes)
                //
                //and that get expects an Expression (q => q.Id == id)
                //     and a list of strings to be added to the query new List<string> {"Hotels"}
                var hotel  = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" }); //"Country" very important here
                var result = _mapper.Map<HotelDTO>(hotel);
                return       Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, $"Err GetHotels {nameof(GetHotel)}");
                return StatusCode(500, "GetHotels Internal Server Error.");
            }
        }

    }

}

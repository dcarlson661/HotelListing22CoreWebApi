using AutoMapper;
using HotelListing22CoreWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing22CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //in ServiceExtensions.cs where you set up database identities you have this line in the config function
        //var builder = services.AddIdentityCore<ApiUser>(q => { q.User.RequireUniqueEmail = true; });
        // that is how you know to use <ApiUser> as the generic T (type) here
        private readonly UserManager<ApiUser>       _userManager;
        private readonly SignInManager<ApiUser>     _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper                    _mapper;
     //   private readonly IAuthManager               _authManager;

        public AccountController(UserManager<ApiUser> userManager, 
                                 SignInManager<ApiUser> signInManager,
                                 ILogger<AccountController> logger, 
                                 IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _signInManager = signInManager;

        }
    }
}

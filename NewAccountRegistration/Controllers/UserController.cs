using Microsoft.AspNetCore.Mvc;
using NewAccountRegistration.DataTransferModel;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewAccountRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;


        public UserController(IConfiguration configuration ,ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));            
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> Get()
        {
            var userDetails = (await _userService.GetUserDetails()).ToList();
            return Ok(userDetails);
        }

        // GET api/<UserController>/196900049H
        [HttpGet("[action]/{SingpassID}")]
        [ActionName("GetJarvis")]
        public async Task<ActionResult<string>> GetBusinessDetails_Jarvis(string SingpassID)
        {           
            if (SingpassID == null)
            {
                return BadRequest();
            }
            var jarvisUser = await _userService.GetJarvisUser(SingpassID);
            await _userService.SaveUserStateAsync(jarvisUser);
            await _userService.GetUserStateAsync(SingpassID);
            if (jarvisUser == null)
            {
                return NotFound();
            }
            return Ok (jarvisUser);
        }

        [HttpGet("[action]/{Postalcode}")]
        [ActionName("GetAddress")]
        public async Task<ActionResult<GetAddressDto>> GetAddress(int Postalcode)
        {
            if (Postalcode == null)
            {
                return BadRequest();
            }

            return Ok(await _userService.GetAddress(Postalcode));            
        }

            // POST api/<UserController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5        
        [HttpPut("[action]")]
        [ActionName("UpdateJarvisUser")]
        public async Task<ActionResult<string>> Put( [FromBody] GetJarvisInfo jarvisInfo)
        {
            if (jarvisInfo == null)
            {
                return BadRequest();
            }
            var jarvisUser = await _userService.UpdateJarvisUser(jarvisInfo);
            if (jarvisUser == null)
            {
                return NotFound();
            }
            return Ok(jarvisUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("MyInfo/{Id}")]
        public async Task<ActionResult<MyInfo>> GetMyinfo(int Id)
        {
            var userDetails = await _userService.GetMyinfo(Id) ;
            return Ok(userDetails);
        }
    }
}
    
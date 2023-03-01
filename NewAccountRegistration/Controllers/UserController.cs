using Microsoft.AspNetCore.Mvc;
using NewAccountRegistration.DataTransferModel;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewAccountRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;


        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
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
            if (jarvisUser == null)
            {
                return NotFound();
            }
            return Ok (jarvisUser);
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
    }
}
    
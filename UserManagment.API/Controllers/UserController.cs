using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using UserManagment.API.Model;
using UserManagment.Domain.User;
using UserManagmentEventSsore.Commands.Commands;
using UserManagmentEventStore.Queries.Queries;

namespace UserManagment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IQueriesService queriesService;

        private readonly ICommandsService commandsService;


        public UserController(IQueriesService _queriesService, ICommandsService _commandsService)
        {
            queriesService = _queriesService;
            commandsService = _commandsService;
        }


        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(object))]
        public IActionResult GenerateUser([FromBody] GenerateUserDto user)
        {
            var insertedUserId = commandsService.CreateUser(user.FirstName, user.LastName);
            return Ok( insertedUserId.ToString() );
        }

        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(UserDto))]
        public IActionResult GetUser([FromQuery] string userId)
        {
            return Ok(queriesService.GetUser(userId));
        }

        [HttpPut]
        [Route("updateAddress")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        public IActionResult ChangeUserAddress([FromQuery] string userId,[FromBody] AddressDto address)
        {
            commandsService.UpdateUserAddress(new UserId(userId),address.City, address.Country, address.Street, address.ZipCode);
           return Ok(new { message = "User Update" });
        }
    }
}

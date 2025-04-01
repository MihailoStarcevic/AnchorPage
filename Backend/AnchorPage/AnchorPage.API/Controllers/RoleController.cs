using AnchorPage.Application;
using AnchorPage.Application.Commands;
using AnchorPage.Application.DataTransfer;
using AnchorPage.Application.Queries;
using AnchorPage.Application.Searches;
using AnchorPage.Implementation.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnchorPage.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RoleController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search, [FromServices] IGetRolesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto dto, [FromServices] ICreateRoleCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok();
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto, [FromServices] IUpdateRoleCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok();
        }
    }
}

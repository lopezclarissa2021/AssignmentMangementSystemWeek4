using AssignmentManagement.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _service;

        public AssignmentController(IAssignmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Assignment>> GetAll()
        {
            return Ok(_service.ListAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Assignment assignment)
        {
            var success = _service.AddAssignment(assignment);
            if (!success)
                return Conflict("Assignment with the same title already exists.");

            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpDelete("{title}")]
        public IActionResult Delete(string title)
        {
            var success = _service.DeleteAssignment(title);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

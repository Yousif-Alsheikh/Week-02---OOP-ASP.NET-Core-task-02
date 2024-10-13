using Aon_Freelance.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aon_Freelance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Projects : ControllerBase
    {
        private static List<Project> ProjectsList = new List<Project>();


        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(ProjectsList);
        }
             
        
        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            ProjectsList.Add(project);

            return CreatedAtAction("Create", new { Id = project.Id }, ProjectsList);
        }



        [HttpGet("{id}")]
        public IActionResult GetFreelancer(int id)
        {
            Project pr = ProjectsList.FirstOrDefault(pr => pr.Id == id);

            if (pr == null)
            {
                return NotFound("The resoucre is not found!");
            }

            return Ok(pr);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Project pr = ProjectsList.FirstOrDefault(pr => pr.Id == id);
            if (pr != null)
            {
                ProjectsList.Remove(pr);
                return Ok("Deleted");

            }

            return NotFound();
        }

    }
}

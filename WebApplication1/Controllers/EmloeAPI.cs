using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Db;
using WebApplication1.Models1;
using WebApplication1.Data;
using WebApplication1.Models1.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmloeAPI : ControllerBase
    {
        private readonly ILogo _logo;
        private readonly DbContact _contact;
        

        public EmloeAPI()
        {

            _contact = new DbContact();

            _logo = new LogoService(_contact);
        }



        [HttpPost("post_employee")]
        public IActionResult PostRt()
        {
            var employees = _logo.WorkerList();
            return Ok(employees);
            _contact.Dispose();
        }
    }
}

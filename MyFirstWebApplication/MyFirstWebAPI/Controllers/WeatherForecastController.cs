using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        readonly ILogger<WeatherForecastController> _logger;
        static List<Employee> Employees = new List<Employee>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpPost("{id},{name},{Address}")]
        public ActionResult AddnewEmployee(int id, string name, string Address)
        {
            Employee employee = new Employee();
            employee.Id = id;
            employee.Name = name;
            employee.Address = Address;
            Employees.Add(employee);
            return Ok(Employees);
        }




        [HttpPut("{toUpdateId},{name},{Address}")]
        public ActionResult UpdateEmployee(int toUpdateId, string name, string Address)
        {
            int status = 0;
            for (int i = 0; i < Employees.Count; i++)
            {
                Employee employee = Employees[i];
                if (employee.Id == toUpdateId)
                {
                    employee.Name = name;
                    employee.Address = Address;
                }
            }
            if (status == 0)
            {
                return Ok("Record not found to updated ");
            }
            return Ok("Updated");
        }

        //[Route("GetAllEmp")]

        [HttpGet]
        public ActionResult GetAllEmployee()
        {

            return Ok(Employees);
        }
        
        [HttpPatch("{id},{name},{address}")]
        public ActionResult AlsoAddnewEmployee(int id, string name, string address)
        {
            Employee employee = new Employee { Id = id, Name = name, Address = address };
            Employees.Add(employee);
            return Ok("Employee Added");
        }

        [HttpDelete("{id}")]
        public ActionResult delEmp(int id)
        {
            var delemp = Employees.Where(emp => emp.Id == id).FirstOrDefault();
            if (delemp != null)
            {
                Employees.Remove(delemp); 
            }
            if(delemp == null)
            {
                return Ok("No Emp Found");
            }
            return Ok("Emp Deleted");
        }
    }

}
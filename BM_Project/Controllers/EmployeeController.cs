using BMEmployee.Core.DTO;
using BMEmployee.Service.Services.EmployeeS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMEmployee.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeService _employeService;

		public EmployeeController(IEmployeService employeService)
        {
			_employeService = employeService;
		}

        [HttpPost]
		public async Task<IActionResult> AddEmployee([FromForm]EmployeeDTO emp)
		{
			await _employeService.CreateService(emp);

			GeneralResponse generalResponse = new GeneralResponse();
			if(emp != null) {
				generalResponse.IsSuccess= true;
				generalResponse.Data = emp;


			}
			else
			{
				generalResponse.IsSuccess = false;
				generalResponse.Data = "Empty";

			}


			return Created();
		}
	}
}

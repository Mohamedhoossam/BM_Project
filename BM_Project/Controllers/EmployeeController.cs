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
			GeneralResponse generalResponse = new GeneralResponse();

			generalResponse= await _employeService.CreateService(emp);

			return Ok(generalResponse);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GeneralResponse>> GetById(Guid id)
		{
			GeneralResponse generalResponse = new GeneralResponse();
			generalResponse = await _employeService.GetByIdService(id);

			if (generalResponse.IsSuccess)
			{
				return Ok(generalResponse);
			}
			else
			{
				return BadRequest("No employee found with this number");
				
			}
		}

		[HttpGet]
		public async Task<ActionResult<GeneralResponse>> GetAll()
		{

			GeneralResponse generalResponse= new GeneralResponse();

			generalResponse = await _employeService.GetAllService();

			if(generalResponse.IsSuccess)
			{
				return Ok(generalResponse);
			}
			return BadRequest();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			await _employeService.DeleteService(id);
			return NoContent();

		}

		[HttpPut]
		public async Task<ActionResult> Update([FromQuery]EmployeUpdateDto employeeDTO, [FromQuery] Guid id)
		{

			GeneralResponse generalResponse = new GeneralResponse();
			generalResponse = await _employeService.UpdateService(employeeDTO, id);
			if(generalResponse.IsSuccess)
			{
				return Ok(generalResponse);
			}
			return BadRequest(generalResponse);
		}

	}
}

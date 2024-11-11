
using BMEmployee.Core.DTO;
using BMEmployee.Service.Services.DepartmentS;
using BMEmployee.Service.Services.EmployeeS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMEmployee.UI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{

		private readonly IDepartmentService _departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpPost]
		public async Task<IActionResult> AddDepartment([FromForm] DepartmentCreateDTO dep)
		{
			GeneralResponse generalResponse = new GeneralResponse();

			generalResponse = await _departmentService.CreateService(dep);

			return Ok(generalResponse);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GeneralResponse>> GetById(Guid id)
		{
			GeneralResponse generalResponse = new GeneralResponse();
			generalResponse = await _departmentService.GetByIdService(id);

			if (generalResponse.IsSuccess)
			{
				return Ok(generalResponse);
			}
			else
			{
				return BadRequest("No department found with this number");

			}
		}

		[HttpGet]
		public async Task<ActionResult<GeneralResponse>> GetAll()
		{

			GeneralResponse generalResponse = new GeneralResponse();

			generalResponse = await _departmentService.GetAllService();

			if (generalResponse.IsSuccess)
			{
				return Ok(generalResponse);
			}
			return BadRequest();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			await _departmentService.DeleteService(id);
			return NoContent();

		}

		[HttpPut]
		public async Task<ActionResult> Update([FromQuery] DrpartmentUpdateDTO departmentDto, [FromQuery] Guid id)
		{

			GeneralResponse generalResponse = new GeneralResponse();
			generalResponse = await _departmentService.UpdateService(departmentDto, id);
			if (generalResponse.IsSuccess)
			{
				return Ok(generalResponse);
			}
			return BadRequest(generalResponse);
		}

	}
}

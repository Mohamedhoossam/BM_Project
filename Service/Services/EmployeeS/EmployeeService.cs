using BMEmployee.Core.DTO;
using BMEmployee.Core.Entities;
using BMEmployee.Core.Interfaces;
using BMEmployee.Service.Services.EmployeeS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Service.Services.EmployeeS
{
	public class EmployeeService : IEmployeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public EmployeeService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

		public async Task<GeneralResponse> CreateService(EmployeeDTO entity)
		{

			GeneralResponse generalResponse = new GeneralResponse();

			await _unitOfWork.EmployeeRepository.Add(new Employee() {
			Email = entity.Email,
			Address = entity.Address,
			Name= entity.Name,
			Phone= entity.Phone,
			Title= entity.Title,
			});
		int count=	await _unitOfWork.Complete();
			if(count > 0 )
			{
				generalResponse.IsSuccess = true;

			}
			else
			{
				generalResponse.IsSuccess= false;
			}

			return generalResponse;
		}

		public async Task DeleteService(Guid id)
		{
			var emp = await _unitOfWork.EmployeeRepository.GetByID(id);
			_unitOfWork.EmployeeRepository.Delete(emp);
			_unitOfWork.Complete();
		}

		public async Task<GeneralResponse> GetAllService()
		{
			GeneralResponse generalResponse = new GeneralResponse();

			var emps = await _unitOfWork.EmployeeRepository.GetAll();

			if(emps != null)
			{
				generalResponse.IsSuccess= true;
				generalResponse.Data=emps;
			}
			else { generalResponse.IsSuccess= false;

				generalResponse.Data = null;
			}

			return generalResponse;
		}

		public async Task<GeneralResponse> GetByIdService(Guid id)
		{
			var emp= await _unitOfWork.EmployeeRepository.GetByID(id);


			GeneralResponse generalResponse = new GeneralResponse();
			if (emp != null)
			{
				generalResponse.IsSuccess = true;
				generalResponse.Data = new EmployeeDTO()
				{
					Address= emp.Address,
					Name= emp.Name,
					Phone= emp.Phone,
					Title= emp.Title,
					Email= emp.Email,
					Image=emp.Image,
				};


			}
			else
			{
				generalResponse.IsSuccess = false;
				generalResponse.Data = null;
			}


	
			return generalResponse;
		
		}

		public async Task<GeneralResponse> UpdateService( EmployeUpdateDto entity, Guid id)
		{
			var emp =  await _unitOfWork.EmployeeRepository.GetByID(id);
			GeneralResponse generalResponse = new GeneralResponse();

			if(emp != null)
			{
				emp.Email = entity.Email ?? emp.Email;
				emp.Name = entity.Name ?? emp.Name;
				emp.Phone = entity.Phone ?? emp.Phone;
				emp.Title = entity.Title ?? emp.Title;
				_unitOfWork.EmployeeRepository.Update(emp);

				var count = await _unitOfWork.Complete();
				generalResponse.IsSuccess = true;
				generalResponse.Data = emp;
			}
			else
			{
				generalResponse.IsSuccess = false;
			}

			return generalResponse;
		}
	}
}

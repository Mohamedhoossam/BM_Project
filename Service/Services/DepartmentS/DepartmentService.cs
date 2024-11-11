using BMEmployee.Core.DTO;
using BMEmployee.Core.Entities;
using BMEmployee.Core.Interfaces;
using BMEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Service.Services.DepartmentS
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GeneralResponse> CreateService(DepartmentCreateDTO entity)
		{
			GeneralResponse generalResponse = new GeneralResponse();
			if(entity != null)
			{
				var dep = new Department()
				{
					Name = entity.DepartmentName,
					Description = entity.DepartmentDescription,
				};

				await _unitOfWork.DepartmentRepository.Add(dep);

				generalResponse.IsSuccess = true;
				generalResponse.Data = dep;
			}
			else
			{
				generalResponse.IsSuccess = false;
			}

			return generalResponse;
	


		}

		public   async Task<GeneralResponse> DeleteService(Guid id)
		{
			GeneralResponse generalResponse=new GeneralResponse();

			var dep= await  _unitOfWork.DepartmentRepository.GetByID(id);
			if(dep != null)
			{
				 _unitOfWork.DepartmentRepository.Delete(dep);
				generalResponse.IsSuccess=true;
				

			}
			else { generalResponse.IsSuccess = false; }

			return generalResponse;
		}

		public async Task<GeneralResponse> GetAllService()
		{
			GeneralResponse generalResponse = new GeneralResponse();

		var result=	await _unitOfWork.DepartmentRepository.GetAll();

			if(result != null)
			{
				generalResponse.IsSuccess= true;
				generalResponse.Data= result;
			}
			else
			{
				generalResponse.IsSuccess= false;
				generalResponse.Data = null;
			}

			return generalResponse;
		}

		public async Task<GeneralResponse> GetByIdService(Guid id)
		{
			GeneralResponse generalResponse = new GeneralResponse();
			var dep = await _unitOfWork.DepartmentRepository.GetByID(id);
			if(dep != null)
			{
				generalResponse.IsSuccess= true;
				generalResponse.Data= dep;
			}
			else
			{
				generalResponse.IsSuccess=false;
				generalResponse.Data = null;
			}

			return generalResponse;
		}

		public  async Task<GeneralResponse> UpdateService(DrpartmentUpdateDTO entity, Guid id)
		{
			GeneralResponse generalResponse = new GeneralResponse();

			var dep = await _unitOfWork.DepartmentRepository.GetByID(id);




			if (dep != null)
			{
				dep.Name = entity.DepartmentName ?? dep.Name;
				dep.Description = entity.DepartmentDescription ?? dep.Name;
				
				_unitOfWork.DepartmentRepository.Update(dep);

				var count = await _unitOfWork.Complete();
				generalResponse.IsSuccess = true;
				generalResponse.Data = dep;
			}
			else
			{
				generalResponse.IsSuccess = false;
			}
			return generalResponse;


		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Core.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{

      
       Task<IEnumerable<T>> GetAll();

		Task<T> GetByID(int id);

		Task Add(T entity);

		void Update(T entity);

		void Delete(T entity);

	}
}

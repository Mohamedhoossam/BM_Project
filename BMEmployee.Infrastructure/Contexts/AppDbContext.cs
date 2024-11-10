using BMEmployee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Infrastructure.Contexts
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }


	}
}

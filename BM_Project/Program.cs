
using BMEmployee.Infrastructure.Contexts;
using BMEmployee.Infrastructure.Repositories;
using BMEmployee.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using BMEmployee.Service.Services.EmployeeS;

namespace BM_Project
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<AppDbContext>(op =>
			{
				op.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
				
			});
			builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
			builder.Services.AddScoped<IEmployeService , EmployeeService>();
			var app = builder.Build();
			
			


			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

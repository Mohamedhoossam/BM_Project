
using BMEmployee.Infrastructure.Contexts;
using BMEmployee.Infrastructure.Repositories;
using BMEmployee.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using BMEmployee.Service.Services.EmployeeS;
using BMEmployee.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			builder.Services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			
			
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(options => //verified key
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = true;
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidIssuer = builder.Configuration["JWT:IssuerIP"],
					ValidateAudience =true,
					ValidAudience = builder.Configuration["JWT:AudienceIP"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecritKey"])),
                };
			});
			
			
			
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("Mypolicy", policy =>
				{
					policy.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();

				});
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

			app.UseCors("Mypolicy");

			//app.UseAuthentication(); by default "cookie"
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

using MediCareLibrary.Data;
using MediCareLibrary.Databases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MediCareLibrary.Models;

namespace MediCareAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUserData, UserSqlData>();
            builder.Services.AddTransient<IMedicalRecordsData, MedicalRecordSqlData>();
            builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

          
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowOrigin");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

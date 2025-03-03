
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi
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

            //JJR 3/1/2025: adding DB context.
            //TO DO: Add SQL Server in place of InMemory DB
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseInMemoryDatabase("LibraryDb"));


            //builder.Services.AddTransient<DataGenerator>()

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
             
            //JJR 3/2/2025: NOTE: below is for testing only
            if (app.Environment.IsDevelopment())
                app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

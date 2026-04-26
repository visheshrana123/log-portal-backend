using LogPortalBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace LogPortalBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // ✅ Swagger enable
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ✅ DB connect
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=logs.db"));

            var app = builder.Build();

            // ✅ Swagger UI enable
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

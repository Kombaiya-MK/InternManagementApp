using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TicketAPI.Interfaces;
using TicketAPI.Models;
using TicketAPI.Services;

namespace TicketAPI
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
            builder.Services.AddDbContext<TicketContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ticketconn"));
                });
            builder.Services.AddScoped<IRepo<Ticket,int> ,TicketRepo>();
            builder.Services.AddScoped<TicketService,TicketService>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
            //builder.Services.AddCors(opts =>
            //{
            //    opts.AddPolicy("MyCors", policy =>
            //    {
            //        policy.AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .AllowAnyOrigin();
            //    });
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
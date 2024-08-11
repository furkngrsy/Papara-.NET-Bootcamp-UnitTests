using Microsoft.AspNetCore.Diagnostics;
using Papara_Bootcamp.Models;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Papara_Bootcamp.Services;
using Papara_Bootcamp.Middlewares;
using FluentValidation;
using Papara_.NET_Bootcamp.DTOs;
using Papara_.NET_Bootcamp.GenreOperations.Commands.CreateGenre;
using Papara_.NET_Bootcamp.Repositories;
using Papara_.NET_Bootcamp.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBookService, FakeBookService>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program)); 
builder.Services.AddScoped<IGenreService, GenreService>(); 
builder.Services.AddScoped<IGenreRepository, GenreRepository>(); 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
builder.Services.AddValidatorsFromAssemblyContaining<CreateGenreCommandValidator>(); 

var app = builder.Build();

app.UseMiddleware<ActionEntryLoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = context.Features.Get<IExceptionHandlerFeature>();

            if (error != null)
            {
                var ex = error.Error;

                var errorResponse = new ApiResponse
                {
                    Success = false,
                    Message = "Beklenmeyen bir hata ger�ekle�ti.",
                    Data = ex.Message
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        });

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core;
using MyAwesomeBlog.Web.Api.Endpoints;
using MyAwesomeBlog.Web.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyAwesomeBlogContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyAwesomeBlog")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<PostsService>()
    .AddScoped<CommentsService>()
    .AddScoped<RatesService>();

builder.Services
    .AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapPostsEndpoints();
app.MapCommentsEndpoints();
app.MapRatesEndpoints();

app.Run();

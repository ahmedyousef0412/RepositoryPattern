using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.EF.DataBase;
using Microsoft.Extensions.Configuration;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.EF.Repositories;
using RepositoryPatternWithUnitOfWork.Core.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbConext>(options =>
options.UseSqlServer
 (builder.Configuration.GetConnectionString("DefaultConnection"),
 b => b.MigrationsAssembly(typeof(ApplicationDbConext).Assembly.FullName)
));


builder.Services.AddAutoMapper(opt => opt.AddProfile(new DomainProfile()));

//Register to IBaseRepository in Api Project
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

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

using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.EF.DataBase;
using Microsoft.Extensions.Configuration;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.EF.Repositories;
using RepositoryPatternWithUnitOfWork.Core.Helper;
using RepositoryPatternWithUnitOfWork.Core.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer
 (builder.Configuration.GetConnectionString("DefaultConnection"),
 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
));


builder.Services.AddAutoMapper(opt => opt.AddProfile(new DomainProfile()));

//Register to IBaseRepository in Api Project

//Using Repository
//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


//Using UnitOfWork
builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();

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

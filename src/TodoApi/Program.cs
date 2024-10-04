using TodoApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = "Server=localhost;Database=TodoList;User Id=sa;Password=Password123!;";

builder.Services.AddControllers();
builder.Services.AddTodoDbContext(connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
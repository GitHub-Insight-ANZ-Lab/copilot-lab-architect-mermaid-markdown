using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddTodoDbContext(this IServiceCollection services, string connectionString)
    {
        // This method adds together 2 integers, returning the sum
        services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
        return services;
    }
}
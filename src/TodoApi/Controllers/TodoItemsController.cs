using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Models;
using TodoApi.Dto;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController(TodoContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            return await context.TodoItems
                .Select(x => ItemToDto(x))
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDto(todoItem);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDto todoItemDto)
        {
            if (id != todoItemDto.Id)
            {
                return BadRequest();
            }

            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            
            todoItem.Name = todoItemDto.Name;
            todoItem.IsComplete = todoItemDto.IsComplete;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemDto todoItemDto)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDto.IsComplete,
                Name = todoItemDto.Name
            };

            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTodoItem), 
                new { id = todoItem.Id }, 
                ItemToDto(todoItem));
        }

        
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return context.TodoItems.Any(e => e.Id == id);
        }

        private static TodoItemDto ItemToDto(TodoItem todoItem) =>
            new()
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}

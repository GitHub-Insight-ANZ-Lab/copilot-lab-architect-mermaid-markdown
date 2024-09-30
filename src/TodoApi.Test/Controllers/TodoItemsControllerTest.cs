using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Controllers;
using TodoApi.Data;
using TodoApi.Data.Models;
using TodoApi.Models;

namespace TodoApi.Test.Controllers
{
    [TestClass]
    public class TodoItemsControllerTest
    {
        private TodoContext _context = null!;
        private TodoItemsController _controller = null!;
        private List<TodoItem> _todoItems = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new TodoContext(options);

            _todoItems =
            [
                new TodoItem { Id = 1, Name = "Test Item 1", IsComplete = false },
                new TodoItem { Id = 2, Name = "Test Item 2", IsComplete = true }
            ];

            _context.TodoItems.AddRange(_todoItems);
            _context.SaveChanges();

            _controller = new TodoItemsController(_context);
        }
        
        [TestMethod]
        public async Task GetTodoItems_ReturnsAllItems()
        {
            var result = await _controller.GetTodoItems();
            
            var items = result.Value;
            Assert.IsNotNull(items);
            Assert.AreEqual(2, items.Count());
        }

        [TestMethod]
        public async Task GetTodoItem_ValidId_ReturnsItem()
        {
            var result = await _controller.GetTodoItem(1);
            
            var item = result.Value;
            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("Test Item 1", item.Name);
        }

        [TestMethod]
        public async Task GetTodoItem_InvalidId_ReturnsNotFound()
        {
            var result = await _controller.GetTodoItem(99);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PutTodoItem_ValidId_ReturnsNoContent()
        {
            var todoItemDto = new TodoItemDto { Id = 1, Name = "Updated Item", IsComplete = true };

            var result = await _controller.PutTodoItem(1, todoItemDto);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            Assert.AreEqual("Updated Item", _todoItems.First(t => t.Id == 1).Name);
            Assert.IsTrue(_todoItems.First(t => t.Id == 1).IsComplete);
        }

        [TestMethod]
        public async Task PutTodoItem_InvalidId_ReturnsBadRequest()
        {
            var todoItemDto = new TodoItemDto { Id = 2, Name = "Updated Item", IsComplete = true };

            var result = await _controller.PutTodoItem(1, todoItemDto);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutTodoItem_NonExistentItem_ReturnsNotFound()
        {
            var todoItemDto = new TodoItemDto { Id = 3, Name = "Updated Item", IsComplete = true };

            var result = await _controller.PutTodoItem(3, todoItemDto);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
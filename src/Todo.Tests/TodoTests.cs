using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Abstractions;
using ToDo.Core.Abstractions.Services;
using ToDo.Core.Models;
using ToDo.Core.Services;
using ToDo.Infrastructure;
using ToDo.Infrastructure.Data;

namespace Todo.Tests
{
    [TestClass]
    public class TodoTests : TestsBase
    {
        IToDoService _todoService;

        [TestInitialize]
        public void Setup()
        {
            _todoService = new ToDoService(UnitOfWork);
        }


        [TestMethod]
        public async Task GetToDoTasks_Should_ReturnValue()
        {
            await AddTestTodo();

            var result = await _todoService.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
        [TestMethod]
        public async Task AddToDoTask_Should_BeAdded()
        {
            var toDo = new ToDoTask
            {
                Name = "Tasks Unit Test",
                DueDate = DateTime.Now
            };

            var result = await _todoService.AddAsync(toDo);
            Assert.IsNotNull(result.Name);
            Assert.AreEqual(toDo.Name, result.Name);
        }

        [TestMethod]
        public async Task UpdateToDoTask_Name_Should_BeUpdated()
        {

            var result = await AddTestTodo();
            result.Name += "_Updated";
            await _todoService.UpdateAsync(result);
            result = await _todoService.GetAsync(result.Id);
            Assert.IsTrue(result.Name.EndsWith("_Updated"));
        }

        [TestMethod]
        public async Task DeleteToDoTask_Should_BeDeleted()
        {
           
            var result = await AddTestTodo();
            
            Assert.IsTrue(result.Id > 0);
            await _todoService.DeleteAsync(result.Id);
            result = await _todoService.GetAsync(result.Id);
            Assert.IsNull(result);
        }




        private async Task<ToDoTask> AddTestTodo()
        {
            var toDo = new ToDoTask
            {
                Name = "Test Task",
                DueDate = DateTime.Now
            };
            UnitOfWork.ToDos.Add(toDo);
            await UnitOfWork.CompleteAsync();
            return toDo;
        }
    }
}

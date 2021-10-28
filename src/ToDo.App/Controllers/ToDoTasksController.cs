using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Abstractions.Services;
using ToDo.Core.Models;
using ToDo.Infrastructure;

namespace ToDo.App.Controllers
{
    public class ToDoTasksController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoTasksController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: ToDoTasks
        public async Task<IActionResult> Index()
        {
            return View(await _toDoService.GetAllAsync());
        }

        // GET: ToDoTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = await _toDoService.GetAsync(id.Value);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // GET: ToDoTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DueDate,IsDone,IsDeleted")] ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                await _toDoService.AddAsync(toDoTask);
                return RedirectToAction(nameof(Index));
            }
            return View(toDoTask);
        }

        // GET: ToDoTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = await _toDoService.GetAsync(id.Value);
            if (toDoTask == null)
            {
                return NotFound();
            }
            return View(toDoTask);
        }

        // POST: ToDoTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DueDate,IsDone,IsDeleted")] ToDoTask toDoTask)
        {
            if (id != toDoTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _toDoService.UpdateAsync(toDoTask);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var i = await _toDoService.GetAsync(toDoTask.Id);
                    if (i == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoTask);
        }

        // GET: ToDoTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = await _toDoService.GetAsync(id.Value);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // POST: ToDoTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _toDoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}

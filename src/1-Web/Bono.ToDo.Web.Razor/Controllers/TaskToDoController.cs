using System.Threading.Tasks;
using Bono.ToDo.Web.Razor.Controllers;
using Bono.ToDo.Web.Razor.HttpClients;
using Bono.ToDo.Web.Razor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vibbra.ToDo.Presentation.Web.Controllers
{
    [Authorize]
    public class TaskToDoController : BaseController
    {
        private readonly TaskToDoApiClient api;

        public TaskToDoController(TaskToDoApiClient api)
        {
            this.api = api;
        }

        [HttpGet]        
        public async Task<IActionResult> Index()
        {
            var tasks = await api.GetAllTaskToDoAsync(CurrentUser.UserId);

            return View(tasks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await api.PostTaskToDoAsync(model);
                }
                catch (System.Exception e)
                {                    
                    System.Console.WriteLine($"Erro: {e.Message}");                    
                    //throw;
                }
                return RedirectToAction("Index", "TaskToDo");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await api.GetTaskToDoAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                await api.PutTaskToDoAsync(model);
                return RedirectToAction("Index", "TaskToDo");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await api.GetTaskToDoAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            await api.DeleteTaskToDoAsync(id);
            return RedirectToAction("Index", "TaskToDo");
        }


    }
}
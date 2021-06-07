using Bono.ToDo.Application.Interfaces;
using Bono.ToDo.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bono.ToDo.Api.TaskToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class TaskToDoController : ControllerBase
    {

        private readonly ITaskToDoService TaskToDoService;

        public TaskToDoController(ITaskToDoService TaskToDoService)
        {
            this.TaskToDoService = TaskToDoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.TaskToDoService.GetAll());
        }

        [HttpGet("GetAll/{userId}")]
        public IActionResult GetAll(Guid? userId)
        {
            return Ok(this.TaskToDoService.GetAll(userId));
        }

        [HttpPost]
        public IActionResult Post(TaskToDoViewModel TaskToDoViewModelViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.TaskToDoService.Post(TaskToDoViewModelViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.TaskToDoService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(TaskToDoViewModel TaskToDoViewModelViewModel)
        {
            return Ok(this.TaskToDoService.Put(TaskToDoViewModelViewModel));
        }

        [HttpDelete]
        public IActionResult Delete(string TaskToDoViewModelId)
        {
            return Ok(this.TaskToDoService.Delete(TaskToDoViewModelId));
        }

        
    }
}
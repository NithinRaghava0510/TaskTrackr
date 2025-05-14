using Microsoft.AspNetCore.Mvc;
using TaskTrackrAPI.Models;
using TaskTrackrAPI.Repositories;
using System.Collections.Generic;

namespace TaskTrackrAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetAll() =>
            Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public ActionResult<TaskItem> Get(int id)
        {
            var task = _repository.Get(id);
            return task is null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> Create(TaskItem task)
        {
            var created = _repository.Create(task);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem task)
        {
            if (id != task.Id) return BadRequest();
            _repository.Update(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TasksApi.Entities;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MojTasksController : ControllerBase
    {
        private readonly IMojTasksRepository _mojTasksRepository;

        public MojTasksController(IMojTasksRepository mojTasksRepository)
        {
            _mojTasksRepository = mojTasksRepository ??
                throw new ArgumentNullException(nameof(mojTasksRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetMojTasks()
        {
            var mojTaskEntities = await _mojTasksRepository.GetMojTasksAsync();
            return Ok(mojTaskEntities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMojTask(int id)
        {
            var mojTaskEntity = await _mojTasksRepository.GetMojTaskAsync(id);
            if (mojTaskEntity == null)
            {
                return NotFound();
            }

            return Ok(mojTaskEntity);

        }

        [HttpPost]
        public async Task<IActionResult> CreateMojTask([FromBody] MojTask newMojTask)
        {
            _mojTasksRepository.CreateMojTask(newMojTask);
            if (await _mojTasksRepository.SaveMojTaskAsync())
            {
                return Created("", newMojTask);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMojForm([FromBody] MojTask newMojTask, int id)
        {
            var mojTaskEntity = await _mojTasksRepository.GetMojTaskAsync(id);

            if (mojTaskEntity is null)
            {
                return NotFound();
            }

            mojTaskEntity.TaskDescription = newMojTask.TaskDescription;
            mojTaskEntity.TaskStatus = newMojTask.TaskStatus;
            mojTaskEntity.TaskDueDate = newMojTask.TaskDueDate;

            _mojTasksRepository.UpdateMojTask(mojTaskEntity);

            if (await _mojTasksRepository.SaveMojTaskAsync())
            {
                return Ok(mojTaskEntity);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMojTask(int id)
        {
            var mojTaskEntity = await _mojTasksRepository.GetMojTaskAsync(id);
            if (mojTaskEntity is null)
            {
                return NotFound();
            }
            _mojTasksRepository.DeleteMojTask(mojTaskEntity);
            if (await _mojTasksRepository.SaveMojTaskAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}

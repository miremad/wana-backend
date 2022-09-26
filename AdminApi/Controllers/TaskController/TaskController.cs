using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Service.TaskService;

namespace AdminApi.Controllers.TaskController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            taskService = _taskService;
        }

        [HttpGet("getTasks")]
        public async Task<IList<TaskDto>> getTasks()
        {
            return await taskService.getTasks();
        }

        [HttpGet("getTaskById/{id:int}")]
        public async Task<TaskDto> getTaskById(int id)
        {
            return await taskService.getTaskById(id);
        }

        [HttpPost("createTask")]
        public async Task<int> createTask(CreateTaskDto input)
        {
            return await taskService.createTaskDto(input);
        }

        [HttpPut("updateTask")]
        public async Task<int> updateTask(UpdateTaskActionDto input)
        {
            return await taskService.updateTaskDto(input);
        }

        [HttpPut("toggleTask/{id:int}")]
        public async Task<bool> toggleTask(int id)
        {
            return await taskService.doneTask(id);
        }



    }
}

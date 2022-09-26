using Model.ViewModel;
using Repository;
using Repository.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TaskService
{
    public class TaskService : ITaskService
    {

        private readonly ITaskRepo taskRepo;
        private readonly IUserRepo userRepo;
        public TaskService(ITaskRepo _taskRepo, IUserRepo _userRepo)
        {
            taskRepo = _taskRepo;
            userRepo = _userRepo;
        }
        public Task<int> createTaskDto(CreateTaskDto input)
        {
            return taskRepo.createTask(input);
        }

        public Task<bool> doneTask(int id)
        {
            return taskRepo.DoneTask(id);
        }

        public Task<TaskDto> getTaskById(int id)
        {
            return taskRepo.getTaskById(id);
        }

        public async Task<IList<TaskDto>> getTasks()
        {
            var userId = userRepo.getCurrentUserId();
            var today = DateTime.Today;
            var res = await taskRepo.getTasks(func: p => p.Where(x => x.UserId == userId).Where(v => v.DeadLineTime >= today).OrderBy(x => x.DeadLineTime).ThenBy(x => x.PeriorityCode));
            return res;
        }

        public Task<int> updateTaskDto(UpdateTaskActionDto input)
        {
            return taskRepo.updateTask(input);
        }
    }
}

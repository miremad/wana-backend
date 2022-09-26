using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TaskService
{
    public interface ITaskService
    {
        Task<IList<TaskDto>> getTasks();
        Task<TaskDto> getTaskById(int id);
        Task<int> createTaskDto(CreateTaskDto input);
        Task<int> updateTaskDto(UpdateTaskActionDto input);
        Task<bool> doneTask(int id);
    }
}

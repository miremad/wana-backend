using Model.Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Task
{
    public interface ITaskRepo
    {
        Task<IList<TaskDto>> getTasks(Func<IQueryable<TaskToDo>, IQueryable<TaskToDo>> func = null);
        Task<int> createTask(CreateTaskDto input);
        Task<int> updateTask(UpdateTaskActionDto input);
        Task<bool> deleteTask(int id);
        Task<bool> DoneTask(int id);
        Task<TaskDto> getTaskById(int id);

    }
}

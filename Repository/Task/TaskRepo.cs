using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Enums;
using Model.Model;
using Model.Utility;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Task
{
    
    public class TaskRepo : ITaskRepo
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public TaskRepo(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> createTask(CreateTaskDto input)
        {
            int userId = _dbContext.getCurrentUserID();
            TaskToDo task = new TaskToDo
            {
                CreatedOn = DateTime.Now,
                IsDone = false,
                Tittle = input.Tittle,
                DeadLineTime = input.DeadLineDate != null && input.DeadLineDate.Length != 0 ? input.DeadLineDate.ToDateTime(): DateTime.Now,
                PeriorityCode = input.PeriorityCode,
                UserId = userId,
                Description = input.Description
            };

            ICollection<TaskLabel> lables = input.Label.Select(x => {
                
                if(x.Id == 0)
                {
                    return new TaskLabel
                    {
                        Label = new Model.Model.Label
                        {
                            Color = x.Color,
                            Tittle = x.Tittle
                        },
                        TaskToDo = task

                    };
                }
                else
                {
                    return new TaskLabel
                    {
                        LabelId = x.Id,
                        TaskToDo = task

                    };
                }
            }
                ).ToList();

            await _dbContext.Set<TaskToDo>().AddAsync(task);
            await _dbContext.Set<TaskLabel>().AddRangeAsync(lables);
            _dbContext.SaveChanges();

            return task.Id;
        }

        public async Task<bool> deleteTask(int id)
        {
            var taskLabels = _dbContext.TaskLabels.Where(x => x.TaskToDoId == id).ToList();
            _dbContext.TaskLabels.RemoveRange(taskLabels);
            var task = await _dbContext.TaskToDos.FindAsync(id);
            _dbContext.TaskToDos.RemoveRange(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DoneTask(int id)
        {
            int userId = _dbContext.getCurrentUserID();
            var task = await _dbContext.TaskToDos.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();
            task.IsDone = !task.IsDone;
            task.DoneOn = DateTime.Now;
            _dbContext.Entry(task).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TaskDto> getTaskById(int id)
        {
            return await _dbContext.TaskToDos.Include(x => x.TaskLabel).Where(x => x.Id == id).ProjectTo<TaskDto>(_mapper.ConfigurationProvider).FirstAsync();
        }

        public async Task<IList<TaskDto>> getTasks(Func<IQueryable<TaskToDo>, IQueryable<TaskToDo>> func = null)
        {
            var query = func != null ? func(_dbContext.TaskToDos) : _dbContext.TaskToDos;
            //var userId = _dbContext.getCurrentUserID();
            var res = query
                .Select(c => new TaskDto
                {
                    CreatedOn = c.CreatedOn.ToShamsiDateTime(),
                    DeadLineTimeShamsi = c.DeadLineTime.ToShamsiDateTime(),
                    DeadLineTime = c.DeadLineTime.Value.ToString("yyyy/MM/dd"),
                    Description = c.Description,
                    DoneOn = c.DoneOn.ToShamsiDateTime(),
                    Id = c.Id,
                    IsDone = c.IsDone,
                    PeriorityCode = c.PeriorityCode.HasValue ? (int)c.PeriorityCode.Value : null,
                    PeriorityCodeValue = c.PeriorityCode.ToString(),
                    Tittle = c.Tittle,
                    Labels = c.TaskLabel.Select(v => new LabelDto
                    {
                        Color = v.Label.Color,
                        Id = v.Label.Id,
                        Tittle = v.Label.Tittle,
                    }).ToList()
                }).ToList();
            return res;
        }

        public async Task<int> updateTask(UpdateTaskActionDto input)
        {
            var task = await _dbContext.TaskToDos.Include(x => x.TaskLabel).Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var newLabelIds = input.Label.Select(v => v.Id).ToList() != null ? input.Label.Select(v => v.Id).ToList() : new List<int>();
            var taskLabelForDelete = _dbContext.TaskLabels.Where(x => x.TaskToDoId == input.Id && !newLabelIds.Contains(x.LabelId)).ToList();
            _dbContext.TaskLabels.RemoveRange(taskLabelForDelete);
            await _dbContext.SaveChangesAsync();

            task.Description = input.Description;
            task.DeadLineTime = input.DeadLineDate.ToDateTime();
            task.DoneOn = input.DoneOn != null? input.DoneOn.ToDateTime() : null ;
            task.PeriorityCode = (PeriorityEnum)input.PeriorityCode;
            task.Tittle = input.Tittle;
            
            var labelToAdd = input.Label.Where(x => !task.TaskLabel.Select(v => v.LabelId).ToList().Contains(x.Id)).ToList();
            ICollection<TaskLabel> taskLabels = labelToAdd.Select(x =>
            {

                if (x.Id == 0)
                {
                    return new TaskLabel
                    {
                        Label = new Model.Model.Label
                        {
                            Color = x.Color,
                            Tittle = x.Tittle
                        },
                        TaskToDo = task

                    };
                }
                else
                {
                    return new TaskLabel
                    {
                        LabelId = x.Id,
                        TaskToDo = task

                    };
                }
            }).ToList();


            await _dbContext.Set<TaskLabel>().AddRangeAsync(taskLabels);
            _dbContext.Entry(task).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return task.Id;
        }
    }
}

using Model;
using Model.Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Label
{
    public class LabelRepo : ILabelRepo
    {
        private readonly AppDBContext _dbContext;

        public LabelRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AssignLabelToTask(AddLabelToTaskActionDto input)
        {
            var taskLabels = input.Labels.Select(x => new TaskLabel
            {
                Label = new Model.Model.Label { Color = x.Color, Tittle = x.Tittle },
                TaskToDoId = input.TaskId
            }).ToList();

            await _dbContext.TaskLabels.AddRangeAsync(taskLabels);
            _dbContext.SaveChanges();

            return true;

        }

        public async Task<bool> DeleteLabel(int id)
        {
            var label = _dbContext.Labels.Find(id);
            var taskLabels = _dbContext.TaskLabels.Where(x => x.LabelId == id).ToList();
            _dbContext.TaskLabels.RemoveRange(taskLabels);
            _dbContext.Labels.Remove(label);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IList<LabelDto>> getLabels()
        {
            var userId = _dbContext.getCurrentUserID();
            var labels = new List<LabelDto>();
            labels = _dbContext.TaskLabels
                .Where(x => x.TaskToDo.UserId == userId)
                .Select(c => new LabelDto
                {
                    Color = c.Label.Color,
                    Id = c.Label.Id,
                    Tittle = c.Label.Tittle
                })
                .Distinct()
                .ToList();

            return labels;
        }
    }
}

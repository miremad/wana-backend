using Model.Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Label
{
    public interface ILabelRepo
    {
        Task<bool> DeleteLabel(int id);
        Task<bool> AssignLabelToTask(AddLabelToTaskActionDto input);
        Task<IList<LabelDto>> getLabels();
    }
}

using Model.Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LabelService
{
    public interface ILabelService
    {
        Task<bool> assignLabelToTask(AddLabelToTaskActionDto input);
        Task<bool> DeleteLabel(int id);
        Task<IList<LabelDto>> getLabels();
    }
}

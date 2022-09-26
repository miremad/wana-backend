using Model.Model;
using Model.ViewModel;
using Repository.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LabelService
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepo _labelRepo;

        public LabelService(ILabelRepo labelRepo) 
        {
            _labelRepo = labelRepo;
        }
        public Task<bool> assignLabelToTask(AddLabelToTaskActionDto input)
        {
            return _labelRepo.AssignLabelToTask(input);
        }

        public Task<bool> DeleteLabel(int id)
        {
            return _labelRepo.DeleteLabel(id);
        }

        public Task<IList<LabelDto>> getLabels()
        {
            return _labelRepo.getLabels();
        }
    }
}

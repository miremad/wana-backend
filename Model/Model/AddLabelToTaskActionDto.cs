using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class AddLabelToTaskActionDto
    {
        public int TaskId { get; set; }
        public ICollection<CreateLabelDto> Labels { get; set; }
    }
}

using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class UpdateTaskActionDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public PeriorityEnum? PeriorityCode { get; set; }
        public string? DoneOn { get; set; }
        public string? DeadLineTime { get; set; }
        public string? DeadLineDate { get; set; }
        public string Description { get; set; }
        public ICollection<CreateLabelDto> Label { get; set; }
    }
}

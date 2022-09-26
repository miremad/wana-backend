using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public PeriorityEnum? PeriorityCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DoneOn { get; set; }
        public DateTime? DeadLineTime { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<TaskLabel> TaskLabel { get; set; }
    }
}

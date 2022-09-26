using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class TaskLabel
    {
        public int Id { get; set; }
        public int LabelId { get; set; }
        public virtual Label Label { get; set; }
        public virtual TaskToDo TaskToDo { get; set; }
        public int TaskToDoId { get; set; }
    }
}

using Model.Enums;



namespace Model.ViewModel
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int? PeriorityCode { get; set; }
        public string PeriorityCodeValue { get; set; }
        public string periorityColorClass => PeriorityCode == 1 ? "lightgray" : 
            PeriorityCode == 2 ? "blue":
            PeriorityCode == 3 ? "orange" : "red";
        public string CreatedOn { get; set; }
        public string? DoneOn { get; set; }
        public string? DeadLineTimeShamsi { get; set; }
        public string? DeadLineTime { get; set; }
        public ICollection<LabelDto> Labels { get; set; }

    }
}

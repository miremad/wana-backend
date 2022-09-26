using AutoMapper;
using Model.Model;
using Model.Utility;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.AutoMapper
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskToDo, TaskDto>()
                .ForMember(v => v.PeriorityCode, s => s.MapFrom(b => (int?)b.PeriorityCode))
                .ForMember(v => v.DeadLineTimeShamsi, s => s.MapFrom(b => b.DeadLineTime.ToShamsiDate()))
                .ForMember(x => x.Labels, 
                    s=>s.MapFrom(
                        p => p.TaskLabel.Select(
                            v => new LabelDto 
                            { 
                                Color = v.Label.Color, 
                                Tittle = v.Label.Tittle, 
                                Id = v.Label.Id
                            }
                            )
                        )
                    );

            CreateMap<CreateLabelDto, Label>();

            CreateMap<TaskLabel, TaskDto>()
                .ForMember(x => x.Labels, s => s.MapFrom(p => new TaskLabel { Label = p.Label}))
                .ForMember(v => v.IsDone, b => b.MapFrom(n => n.TaskToDo.IsDone))
                .ForMember(v => v.DeadLineTime, b => b.MapFrom(n => n.TaskToDo.DeadLineTime))
                .ForMember(v => v.CreatedOn, b => b.MapFrom(n => n.TaskToDo.CreatedOn))
                .ForMember(v => v.Tittle, b => b.MapFrom(n => n.TaskToDo.Tittle))
                .ForMember(v => v.Description, b => b.MapFrom(n => n.TaskToDo.Description))
                .ForMember(v => v.DoneOn, b => b.MapFrom(n => n.TaskToDo.DoneOn))
                .ForMember(v => v.Id, b => b.MapFrom(n => n.TaskToDo.Id))
                .ForMember(v => v.PeriorityCode, b => b.MapFrom(n => n.TaskToDo.PeriorityCode))
                .ForMember(v => v.PeriorityCodeValue, b => b.MapFrom(n => n.TaskToDo.PeriorityCode.ToString()));

            
        }
    }
}

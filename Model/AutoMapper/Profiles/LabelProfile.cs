using AutoMapper;
using Model.Model;
using Model.ViewModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.AutoMapper
{
    public class LabelProfile: Profile
    {
        public LabelProfile()
        {
            CreateMap<CreateLabelDto, Label>();

            CreateMap<Label, LabelDto>();
        }
    }
}

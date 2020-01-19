using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SMSe.BLL.ModelViews;
using SMSe.DAL;

namespace SMSe.BLL.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherView>()
                .ForMember(vm => vm.id, map => map.MapFrom(m => m.id))
                .ForMember(vm => vm.fname, map => map.MapFrom(m => m.fname))
                .ForMember(vm => vm.fname, map => map.MapFrom(m => m.fname))
                .ForMember(vm => vm.Subject_Teacher, map => map.MapFrom(m => m.Subject_Teacher));
            CreateMap<TeacherView, Teacher>()
                .ForMember(vm => vm.id, map => map.MapFrom(m => m.id))
                .ForMember(vm => vm.fname, map => map.MapFrom(m => m.fname))
                .ForMember(vm => vm.fname, map => map.MapFrom(m => m.fname))
                .ForMember(vm => vm.Subject_Teacher, map => map.MapFrom(m => m.Subject_Teacher));
            CreateMap<Subject, SubjectView>()
                .ForMember(vm => vm.id, map => map.MapFrom(m => m.id))
                .ForMember(vm => vm.name, map => map.MapFrom(m => m.name))
                .ForMember(vm => vm.total_hour, map => map.MapFrom(m => m.total_hour))
                .ForMember(vm => vm.Subject_Teacher, map => map.MapFrom(m => m.Subject_Teacher));
            CreateMap<SubjectView, Subject>()
                .ForMember(vm => vm.id, map => map.MapFrom(m => m.id))
                .ForMember(vm => vm.name, map => map.MapFrom(m => m.name))
                .ForMember(vm => vm.total_hour, map => map.MapFrom(m => m.total_hour))
                .ForMember(vm => vm.Subject_Teacher, map => map.MapFrom(m => m.Subject_Teacher));
        }
    }
}

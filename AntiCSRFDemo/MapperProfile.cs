using AntiCSRFDemo.Models;
using AutoMapper;

namespace AntiCSRFDemo
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentDTO, Student>().ForSourceMember(src => src.ID, opt => opt.DoNotValidate());
        }
    }
}
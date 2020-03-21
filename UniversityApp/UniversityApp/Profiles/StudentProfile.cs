using AutoMapper;
using UniversityApp.DataTransferObjects;
using UniversityApp.Models;

namespace UniversityApp.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ReverseMap();
        }
    }
}

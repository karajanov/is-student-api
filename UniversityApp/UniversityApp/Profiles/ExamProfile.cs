using AutoMapper;
using UniversityApp.DataTransferObjects;
using UniversityApp.Models;

namespace UniversityApp.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamViewModel>()
                .ReverseMap();
        }
    }
}

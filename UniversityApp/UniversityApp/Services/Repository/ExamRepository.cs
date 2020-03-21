using UniversityApp.Models;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Services.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(UniversityAppContext context)
            : base(context)
        {
        }

    }
}

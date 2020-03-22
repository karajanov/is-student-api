using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface IExamRepository : IRepository<Exam>
    { 
        Task<decimal?> GetLowestExamCreditsAsync();

        Task<decimal?> GetHighestExamCreditsAsync();

        Task<ExamViewModel> GetExamByIdAsync(int id);

        Task<IEnumerable<ExamViewModel>> GetAllAsync();

        Task<QExtendedExamInfo> GetExamBySubjectAsync(string subject);

        Task<IEnumerable<QExamByCredits>> GetExamsWithLowestCreditsAsync();

        Task<IEnumerable<QExamByCredits>> GetExamsWithHighestCreditsAsync();

        Task<IEnumerable<QExamByCredits>> GetExamsByCreditsAsync(decimal credits);

        Task<IEnumerable<QExtendedExamInfo>> GetExamsByProfessorAsync(string professor);
    }
}

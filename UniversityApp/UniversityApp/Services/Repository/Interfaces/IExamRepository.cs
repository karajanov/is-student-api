using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface IExamRepository : IRepository<Exam>
    {
        Task<decimal?> GetLowestExamCreditsAsync();

        Task<decimal?> GetHighestExamCreditsAsync();

        Task<IEnumerable<QExamByCredits>> GetExamsWithLowestCreditsAsync();

        Task<IEnumerable<QExamByCredits>> GetExamsWithHighestCreditsAsync();

        Task<IEnumerable<QExamByCredits>> GetExamsByCreditsAsync(decimal credits);

        //    Task<QExamBySubject> GetExamBySubjectAsync(string subject);

        //    Task<IEnumerable<QExamByCredits>> GetExamsWithLowestCreditsAsync();

        //    Task<IEnumerable<QExamByCredits>> GetExamsWithHighestCreditsAsync();

        //    Task<IEnumerable<QExamByCredits>> GetExamByCreditAsync(decimal credit);

        //    Task<IEnumerable<QExamByProfessor>> GetExamsByProfessorAsync(string professor);

    }
}

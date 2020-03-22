using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversityApp.Services.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(UniversityAppContext context)
            : base(context)
        {
        }

        public async Task<decimal?> GetLowestExamCreditsAsync()
        {
            return await GetEntity().MinAsync(e => e.Credits);
        }

        public async Task<decimal?> GetHighestExamCreditsAsync()
        {
            return await GetEntity().MaxAsync(e => e.Credits);
        }

        public async Task<IEnumerable<QExamByCredits>> GetExamsWithLowestCreditsAsync()
        {
            var minCredits = await GetLowestExamCreditsAsync();

            var examList = await GetEntity()
                .Where(e => e.Credits == minCredits)
                .Select(e => new QExamByCredits()
                {
                    Id = e.Id,
                    Subject = e.Name,
                    Professor = e.ProfessorName,
                    Credits = e.Credits
                })
                .ToListAsync();

            return examList;
        }

        public async Task<IEnumerable<QExamByCredits>> GetExamsWithHighestCreditsAsync()
        {
            var maxCredits = await GetHighestExamCreditsAsync();

            var examList = await GetEntity()
               .Where(e => e.Credits == maxCredits)
               .Select(e => new QExamByCredits()
               {
                   Id = e.Id,
                   Subject = e.Name,
                   Professor = e.ProfessorName,
                   Credits = e.Credits
               })
               .ToListAsync();

            return examList;
        }

        public async Task<IEnumerable<QExamByCredits>> GetExamsByCreditsAsync(decimal credits)
        {
            var examList = await GetEntity()
                .Where(e => e.Credits == credits)
                .Select(e => new QExamByCredits()
                {

                })
                .ToListAsync();

            return examList;
        }

    }
}

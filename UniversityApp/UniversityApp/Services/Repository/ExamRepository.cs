using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityApp.DataTransferObjects;
using AutoMapper;
using UniversityApp.Extensions;

namespace UniversityApp.Services.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        private readonly IMapper mapper;
        private readonly DbSet<Student> students;
        private readonly DbSet<Transcript> transcripts;

        public ExamRepository(UniversityAppContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
            students = context.Set<Student>();
            transcripts = context.Set<Transcript>();
        }

        public async Task<decimal?> GetLowestExamCreditsAsync()
        {
            return await GetEntity().MinAsync(e => e.Credits);
        }

        public async Task<decimal?> GetHighestExamCreditsAsync()
        {
            return await GetEntity().MaxAsync(e => e.Credits);
        }

        public async Task<ExamViewModel> GetExamByIdAsync(int id)
        {
            var exam = await GetEntity()
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            var evm = mapper.Map<ExamViewModel>(exam);

            return evm;
        }

        public async Task<IEnumerable<ExamViewModel>> GetAllAsync()
        {
            var examList = await GetEntity().ToListAsync();

            var evmList = mapper.MapList<ExamViewModel, Exam>(examList);

            return evmList;
        }

        public async Task<QExtendedExamInfo> GetExamBySubjectAsync(string subject)
        {
            var exam = await GetEntity()
                .Where(e => e.Name == subject)
                .FirstOrDefaultAsync();

            if (exam == null)
                return null;

            var studentList = await (from s in students
                                     join t in transcripts on s.Id equals t.StudentId
                                     where t.ExamId == exam.Id
                                     select s)
                            .ToListAsync();

            return new QExtendedExamInfo()
            {
                ExamInfo = mapper.Map<ExamViewModel>(exam),
                StudentList = mapper.MapList<StudentViewModel, Student>(studentList)
            };
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
                    Id = e.Id,
                    Subject = e.Name,
                    Professor = e.ProfessorName,
                    Credits = e.Credits
                })
                .ToListAsync();

            return examList;
        }

        public async Task<IEnumerable<QExtendedExamInfo>> GetExamsByProfessorAsync(string professor)
        {
            var exam = await GetEntity()
                .Where(e => e.ProfessorName == professor)
                .ToListAsync();

            var studentList = await (from s in students
                                     join t in transcripts on s.Id equals t.StudentId
                                     where t.ExamId == exam.Id
                                     select s)
                            .ToListAsync();

            return new QExtendedExamInfo()
            {
                ExamInfo = mapper.Map<ExamViewModel>(exam),
                StudentList = mapper.MapList<StudentViewModel, Student>(studentList)
            };
        }

    }
}

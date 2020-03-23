using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Services.Repository
{
    public class TranscriptRepository : Repository<Transcript>, ITranscriptRepository
    {
        public TranscriptRepository(UniversityAppContext context)
            : base(context)
        {}

        public async Task<IEnumerable<int>> GetTranscriptIdsByStudentIdAsync(int studentId)
        {
            return await GetEntity()
                .Where(t => t.StudentId == studentId)
                .Select(t => t.Id)
                .ToListAsync();
        }

        public async Task<bool> DeleteMultipleTranscriptsAsync(List<int> transcriptIds)
        {
            if (transcriptIds == null || transcriptIds.Count == 0)
                return false;

            foreach(var transcriptId in transcriptIds)
            {
                try
                {
                    await DeleteAsync(transcriptId);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

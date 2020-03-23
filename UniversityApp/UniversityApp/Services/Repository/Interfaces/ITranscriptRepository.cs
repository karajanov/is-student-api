using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Models;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface ITranscriptRepository : IRepository<Transcript>
    {
        Task<IEnumerable<int>> GetTranscriptIdsByStudentIdAsync(int studentId);

        Task<IEnumerable<int>> GetTranscriptIdsByExamIdAsync(int examId);
    }
}

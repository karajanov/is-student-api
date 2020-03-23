using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface ITranscriptRepository
    {
        Task<IEnumerable<int>> GetTranscriptIdsByStudentIdAsync(int studentId);

        Task<bool> DeleteMultipleTranscriptsAsync(List<int> transciptIdsList);
    }
}

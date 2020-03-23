using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Models;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<int>> GetStudentIdsByAddressIdAsync(int addressId);
    }
}

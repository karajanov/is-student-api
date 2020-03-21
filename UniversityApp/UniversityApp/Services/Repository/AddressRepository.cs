using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversityApp.Services.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly DbSet<Student> students;

        public AddressRepository(UniversityAppContext context)
            : base(context)
        {
            students = context.Set<Student>();
        }

        public async Task<QAddressByStreet> GetAddressByStreetAsync(string street)
        {
            var c = new QAddressByStreet();

            var address = await (from a in GetEntity()
                           join s in students on a.Id equals s.AddressId
                           where a.Street == street
                           select c).FirstOrDefaultAsync();

            return address;
        }
    }
}

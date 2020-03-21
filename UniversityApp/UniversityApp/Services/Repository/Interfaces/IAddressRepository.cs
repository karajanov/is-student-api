using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<QAddressByStreet> GetAddressByStreetAsync(string street);

      // Task<IEnumerable<QAddressByCity>> GetAddressesByCity(string city);

       // Task<IEnumerable<QAddressByCountry>> GetAddressesByCountry(string country);
    }
}

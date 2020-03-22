using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;

namespace UniversityApp.Services.Repository.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    { 
        Task<IEnumerable<AddressViewModel>> GetAllAsync();

        Task<AddressViewModel> GetAddressInfoByIdAsync(int id);

        Task<QAddressByStreet> GetAddressByStreetAsync(string street);

        Task<IEnumerable<QAddressByCity>> GetAddressesByCityAsync(string city);

        Task<QAddressByStudentIndex> GetAddressByStudentIndexAsync(string index);

        Task<IEnumerable<QAddressByCountry>> GetAddressesByCountryAsync(string country);
    }
}

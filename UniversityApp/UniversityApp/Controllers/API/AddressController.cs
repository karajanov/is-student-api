using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.DataTransferObjects;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        
        [HttpGet]
        [Route("All")] // api/Address/All
        public async Task<IEnumerable<AddressViewModel>> GetAllAsync()
        {
            return await addressRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")] // api/Address/{id}
        public async Task<AddressViewModel> GetByIdAsync([FromRoute] int id)
        {
            return await addressRepository.GetAddressInfoByIdAsync(id);
        }

        [HttpGet]
        [Route("Street")] // api/Address/Street?name=value
        public async Task<QAddressByStreet> GetAddressByStreetAsync([FromQuery] string name)
        {
            return await addressRepository.GetAddressByStreetAsync(name);
        }

        [HttpGet]
        [Route("City")] // api/Address/City?name=value
        public async Task<IEnumerable<QAddressByCity>> GetAddressesByCityAsync([FromQuery] string name)
        {
            return await addressRepository.GetAddressesByCityAsync(name);
        }

        [HttpGet]
        [Route("Country")] // api/Address/Country?name=value
        public async Task<IEnumerable<QAddressByCountry>> GetAddressesByCountryAsync([FromQuery] string name)
        {
            return await addressRepository.GetAddressesByCountryAsync(name);
        }

        [HttpGet] 
        [Route("Student")] // api/Address/Student?index=value
        public async Task<QAddressByStudentIndex> GetAddressByStudentIndexAsync([FromQuery] string index)
        {
            return await addressRepository.GetAddressByStudentIndexAsync(index);
        }

        
        // POST: api/Address
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Address/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

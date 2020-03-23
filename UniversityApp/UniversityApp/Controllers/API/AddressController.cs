using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.DataTransferObjects;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAddressRepository addressRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITranscriptRepository transcriptRepository;
        
        public AddressController
            (IAddressRepository addressRepository,
            IStudentRepository studentRepository,
            ITranscriptRepository transcriptRepository,
            IMapper mapper)
        {
            this.transcriptRepository = transcriptRepository;
            this.addressRepository = addressRepository;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [Route("All")] // api/Address/All
        public async Task<IEnumerable<AddressViewModel>> GetAllAsync()
        {
            return await addressRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")] // api/Address/{id}
        public async Task<QAddressById> GetByIdAsync([FromRoute] int id)
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

        
        [HttpPost] // api/Address
        public async Task<IActionResult> PostNewAddressAsync([FromBody] AddressViewModel avm)
        {
            if (!ModelState.IsValid)
                Forbid("Invalid address model");

            try
            {
                var address = mapper.Map<Address>(avm);
                await addressRepository.InsertAsync(address);
            }
            catch(Exception)
            {
                return StatusCode(500, "Address couldn't be inserted");
            }

            return StatusCode(201, "Address successfully inserted");
        }

        [HttpPut("{id}")] // api/Address/{id}
        public async Task<IActionResult> PutNewAddressAsync(int id, [FromBody] AddressViewModel avm)
        {
            var existingAddress = await addressRepository.GetAddressInfoByIdAsync(id);

            if (existingAddress == null)
                return NotFound("Invalid address id");

            if (!ModelState.IsValid)
                return Forbid("Invalid address model");

            try
            {
                var address = mapper.Map<Address>(avm);
                address.Id = id;
                await addressRepository.UpdateAsync(address);
            }
            catch (Exception)
            {
                return StatusCode(500, "Address couldn't be updated");
            }

            return Ok("Address successfully updated");
        }

        [HttpDelete("{id}")] // api/Address/{id}
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            var existingAddress = await addressRepository.GetAddressInfoByIdAsync(id);

            if (existingAddress == null)
                return NotFound("Invalid address id");

            var studentIdsList = await studentRepository.GetStudentIdsByAddressIdAsync(id);

            //Deleting all transcript that are dependent on the students that have the provided address id
            foreach(var studentId in studentIdsList)
            {
                var transcriptIdsList = await transcriptRepository.GetTranscriptIdsByStudentIdAsync(studentId);

                var isSuccessful = await transcriptRepository
                    .DeleteMultipleRecordsAsync(transcriptIdsList);

                if (!isSuccessful)
                    return StatusCode(500, "Address couldn't be deleted");
            }

            //Deleting all student objects that are dependent on the address
             var isSuccessfulTwo = await studentRepository
                .DeleteMultipleRecordsAsync(studentIdsList);

            if (!isSuccessfulTwo)
                return StatusCode(500, "Address couldn't be deleted");

            //Deleting the address
            try
            {
                await addressRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Address couldn't be deleted");
            }

            return Ok("Address successfully deleted");
        }
    }
}

﻿using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityApp.DataTransferObjects;
using AutoMapper;
using UniversityApp.Extensions;

namespace UniversityApp.Services.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly IMapper mapper;
        private readonly DbSet<Student> students;

        public AddressRepository(UniversityAppContext context, IMapper mapper)
            : base(context)
        {
            students = context.Set<Student>();
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AddressViewModel>> GetAllAsync()
        {
            var addressList = await GetEntity().ToListAsync();

            var mappedList = mapper.MapList<AddressViewModel, Address>(addressList);

            return mappedList;
        }

        public async Task<QAddressById> GetAddressInfoByIdAsync(int id)
        {
            var address = await GetEntity()
                .AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (address == null)
                return null;

            var studentList = await students
                .Where(s => s.AddressId == address.Id)
                .ToListAsync();

            return new QAddressById()
            {
                AddressInfo = mapper.Map<AddressViewModel>(address),
                StudentList = mapper.MapList<StudentViewModel, Student>(studentList)
            };

        }

        public async Task<QAddressByStreet> GetAddressByStreetAsync(string street)
        {
            var address = await (from a in GetEntity()
                                 join s in students on a.Id equals s.AddressId
                                 where a.Street == street
                                 select new QAddressByStreet()
                                 {
                                     AddressId = a.Id,
                                     StudentName = s.FirstName,
                                     StudentSurname = s.LastName,
                                     StudentIndex = s.StudentIndex,
                                     City = a.City,
                                     Country = a.Country
                                 })
                                 .FirstOrDefaultAsync();

            return address;
        }

        public async Task<IEnumerable<QAddressByCity>> GetAddressesByCityAsync(string city)
        {
            var addressList = await (from a in GetEntity()
                                     join s in students on a.Id equals s.AddressId
                                     where a.City == city
                                     select new QAddressByCity()
                                     {
                                         AddressId = a.Id,
                                         StudentName = s.FirstName,
                                         StudentSurname = s.LastName,
                                         StudentIndex = s.StudentIndex,
                                         Street = a.Street,
                                         Country = a.Country
                                     })
                                     .ToListAsync();

            return addressList;
        }

        public async Task<QAddressByStudentIndex> GetAddressByStudentIndexAsync(string index)
        {
            var addressList = await (from a in GetEntity()
                                     join s in students on a.Id equals s.AddressId
                                     where s.StudentIndex == index
                                     select new QAddressByStudentIndex()
                                     {
                                         AddressId = a.Id,
                                         StudentName = s.FirstName,
                                         StudentSurname = s.LastName,
                                         Email = s.Mail,
                                         Country = a.Country,
                                         City = a.City,
                                         Street = a.Street
                                     })
                                     .FirstOrDefaultAsync();

            return addressList;
        }
        
        //an inner/left join with the Students table wouldn't be optimal
        //the resulting query could yield thousands of addresses in a single country
        //*in a real life scenario - the same can be stated for the city addresses query
        public async Task<IEnumerable<QAddressByCountry>> GetAddressesByCountryAsync(string country)
        {
            var addressList = await GetEntity()
                .Where(a => a.Country == country)
                .Select(a => new QAddressByCountry()
                {
                    AddressId = a.Id,
                    City = a.City,
                    Street = a.Street
                })
                .ToListAsync();

            return addressList;
        }
    }
}

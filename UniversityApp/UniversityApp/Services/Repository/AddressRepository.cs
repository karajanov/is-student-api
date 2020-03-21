﻿using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.QueryHelpers;
using UniversityApp.Services.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityApp.DataTransferObjects;
using AutoMapper;

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

        public async Task<AddressViewModel> GetAddressInfoByIdAsync(int id)
        {
            var address = await GetEntity()
                .AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            var avm = mapper.Map<AddressViewModel>(address);

            return avm;
        }

        public async Task<IEnumerable<AddressViewModel>> GetAllAsync()
        {
            var addressList = await GetEntity().ToListAsync();
            var mappedList = new List<AddressViewModel>();

            foreach(var item in addressList)
            {
                var avm = mapper.Map<AddressViewModel>(item);
                mappedList.Add(avm);
            }

            return mappedList;
        }

        public async Task<QAddressByStreet> GetAddressByStreetAsync(string street)
        {
            var address = await (from a in GetEntity()
                                 join s in students on a.Id equals s.AddressId
                                 where a.Street == street
                                 select new QAddressByStreet()
                                 {
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
                                         StudentName = s.FirstName,
                                         StudentSurname = s.LastName,
                                         StudentIndex = s.StudentIndex,
                                         Street = a.Street,
                                         Country = a.Country
                                     })
                                     .ToListAsync();

            return addressList;
        }

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
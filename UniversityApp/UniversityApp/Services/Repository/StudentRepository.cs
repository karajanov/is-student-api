﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.Models;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Services.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityAppContext context)
            : base(context)
        {}

        public async Task<IEnumerable<int>> GetStudentIdsByAddressIdAsync(int addressId)
        {
            return await GetEntity()
                .Where(s => s.AddressId == addressId)
                .Select(s => s.Id)
                .ToListAsync();
        }

        public async Task<bool> DeleteMultipleStudentsAsync(List<int> studentIdsList)
        {
            if (studentIdsList == null || studentIdsList.Count == 0)
                return false;

            foreach(var studentId in studentIdsList)
            {
                try
                {
                    await DeleteAsync(studentId);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

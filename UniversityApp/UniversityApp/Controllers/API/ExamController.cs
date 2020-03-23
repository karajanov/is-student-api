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
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository examRepository;

        public ExamController(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        [HttpGet]
        [Route("All")] // api/Exam/All
        public async Task<IEnumerable<ExamViewModel>> GetAllAsync()
        {
            return await examRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")] // api/Exam/{id}
        public async Task<ExamViewModel> GetInfoByIdAsync([FromRoute] int id)
        {
            return await examRepository.GetExamByIdAsync(id);
        }

        [HttpGet]
        [Route("MinCredits")] // api/Exam/MinCredits
        public async Task<decimal?> GetLowestExamCreditsAsync()
        {
            return await examRepository.GetLowestExamCreditsAsync();
        }

        [HttpGet]
        [Route("MaxCredits")] // api/Exam/MaxCredits
        public async Task<decimal?> GetHighestExamCreditsAsync()
        {
            return await examRepository.GetHighestExamCreditsAsync();
        }

        [HttpGet]
        [Route("Min")] // api/Exam/Min
        public async Task<IEnumerable<QExamByCredits>> GetExamsWithLowestCreditsAsync()
        {
            return await examRepository.GetExamsWithLowestCreditsAsync();
        }

        [HttpGet]
        [Route("Max")] // api/Exam/Max
        public async Task<IEnumerable<QExamByCredits>> GetExamsWithHighestCreditsAsync()
        {
            return await examRepository.GetExamsWithHighestCreditsAsync();
        }

        [HttpGet]
        [Route("Credits/{value}")] // api/Exam/Credits/{value}
        public async Task<IEnumerable<QExamByCredits>> GetExamsByCreditsAsync([FromRoute] decimal value)
        {
            return await examRepository.GetExamsByCreditsAsync(value);
        }

        [HttpGet]
        [Route("Subject")] // api/Exam/Subject?name=value
        public async Task<QExtendedExamInfo> GetExamBySubjectAsync([FromQuery] string name)
        {
            return await examRepository.GetExamBySubjectAsync(name);
        }

        [HttpGet]
        [Route("Professor")] //api/Exam/Professor?name=value
        public async Task<IEnumerable<QExtendedExamInfo>> GetExamsByProfessorAsync([FromQuery] string name)
        {
            return await examRepository.GetExamsByProfessorAsync(name);
        } 

        // POST: api/Exam
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Exam/5
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

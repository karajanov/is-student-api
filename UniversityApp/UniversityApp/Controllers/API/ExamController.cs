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
    public class ExamController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IExamRepository examRepository;
        private readonly ITranscriptRepository transcriptRepository;

        public ExamController(
            ITranscriptRepository transcriptRepository,
            IExamRepository examRepository,
            IMapper mapper)
        {
            this.transcriptRepository = transcriptRepository;
            this.examRepository = examRepository;
            this.mapper = mapper;
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

        [HttpPost] // api/Exam
        public async Task<IActionResult> PostNewExamAsync([FromBody] ExamViewModel evm)
        {
            if (!ModelState.IsValid)
                Forbid("Invalid exam model");

            try
            {
                var exam = mapper.Map<Exam>(evm);
                await examRepository.InsertAsync(exam);
            }
            catch (Exception)
            {
                return StatusCode(500, "Exam couldn't be inserted");
            }

            return StatusCode(201, "Exam successfully inserted");
        }

        [HttpPut("{id}")] // api/Exam/{id}
        public async Task<IActionResult> PutNewExamAsync(int id, [FromBody] ExamViewModel evm)
        {
            var existingExam = await examRepository.GetExamByIdAsync(id);

            if (existingExam == null)
                return NotFound("Invalid exam id");

            if (!ModelState.IsValid)
                return Forbid("Invalid exam model");

            try
            {
                var exam = mapper.Map<Exam>(evm);
                exam.Id = id;
                await examRepository.UpdateAsync(exam);
            }
            catch (Exception)
            {
                return StatusCode(500, "Exam couldn't be updated");
            }

            return Ok("Exam successfully updated");
        }

        [HttpDelete("{id}")] // api/Exam/{id}
        public async Task<IActionResult> DeleteExamAsync(int id)
        {
            var existingExam = await examRepository.GetExamByIdAsync(id);

            if (existingExam == null)
                return NotFound("Invalid exam id");

            var transcriptIdsList = await transcriptRepository.GetTranscriptIdsByExamIdAsync(id);

            var isDeletionSuccessful = await transcriptRepository
                .DeleteMultipleRecordsAsync(transcriptIdsList);

            if (!isDeletionSuccessful)
                return StatusCode(500, "Exam couldn't be deleted");

            try
            {
                await examRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Exam couldn't be deleted");
            }

            return Ok("Exam successfully deleted");
        }
    }
}

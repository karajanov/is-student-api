using System.Collections.Generic;
using UniversityApp.DataTransferObjects;

namespace UniversityApp.QueryHelpers
{
    public class QExamBySubject
    {
        public string ProfessorName { get; set; }

        public decimal Credits { get; set; }

        public IEnumerable<StudentViewModel> Students;

    }
}

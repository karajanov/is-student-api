using System.Collections.Generic;
using UniversityApp.DataTransferObjects;

namespace UniversityApp.QueryHelpers
{
    public class QExtendedExamInfo
    {
        public ExamViewModel  ExamInfo { get; set; }

        public IEnumerable<StudentViewModel> StudentList { get; set; }
    }
}

using System.Collections.Generic;

namespace UniversityApp.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProfessorName { get; set; }

        public decimal Credits { get; set; }

        public virtual List<Transcript> Students { get; set; }
    }
}

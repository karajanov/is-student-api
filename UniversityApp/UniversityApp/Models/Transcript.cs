namespace UniversityApp.Models
{
    public class Transcript
    {
        public int Id { get; set; }

        public int ExamId { get; set; }

        public int StudentId { get; set; }

        public decimal Points { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Student Student { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace UniversityApp.DataTransferObjects
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length of 400 exceeded")]
        public string Name { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length of 400 exceeded")]
        public string ProfessorName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public decimal Credits { get; set; }
   }
}

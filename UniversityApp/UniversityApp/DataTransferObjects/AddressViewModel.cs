using System.ComponentModel.DataAnnotations;

namespace UniversityApp.DataTransferObjects
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length of 400 exceeded")]
        public string Street { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length of 400 exceeded")]
        public string City { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length of 400 exceeded")]
        public string Country { get; set; }
    }
}

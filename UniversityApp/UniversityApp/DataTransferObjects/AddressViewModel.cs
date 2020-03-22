using System.Collections.Generic;
using UniversityApp.Models;

namespace UniversityApp.DataTransferObjects
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<Student> Students { get; set; }
    }
}

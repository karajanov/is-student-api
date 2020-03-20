using System.Collections.Generic;

namespace UniversityApp.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual IEnumerable<Student> Students { get; set; }
    }
}

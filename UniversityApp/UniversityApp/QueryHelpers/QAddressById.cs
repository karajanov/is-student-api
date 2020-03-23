using System.Collections.Generic;
using UniversityApp.DataTransferObjects;

namespace UniversityApp.QueryHelpers
{
    public class QAddressById
    {
        public AddressViewModel AddressInfo { get; set; }

        public IEnumerable<StudentViewModel> StudentList { get; set; }
    }
}

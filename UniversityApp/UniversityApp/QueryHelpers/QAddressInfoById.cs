using System.Collections.Generic;
using UniversityApp.DataTransferObjects;

namespace UniversityApp.QueryHelpers
{
    public class QAddressInfoById
    {
        public AddressViewModel Address { get; set; }

        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}

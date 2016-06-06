using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWEN_Delonix_Regia_HMS.model
{
    class Staff
    {
        public int staffId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string bankAccountNumber { get; set; }
        public string staffAddress { get; set; }
        public int phoneNumber { get; set; }
        public int dutyId { get; set; }
        public int accountId { get; set; }
    }
}

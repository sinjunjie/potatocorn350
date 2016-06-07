using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWEN_Delonix_Regia_HMS.model
{
    class Account
    {
        public int accountId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int isAdmin { get; set; }
    }
}

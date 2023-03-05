using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPharma.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public Int64 Phone { get; set; }
        public string Email { get; set; }
        public string PAN { get; set; }
        public Int64 AdhaarNo { get; set; }
        public string Address { get; set; }
    }
}

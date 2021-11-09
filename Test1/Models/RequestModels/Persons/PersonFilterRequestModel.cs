using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Models.RequestModels.Persons
{
    public class PersonFilterRequestModel
    {
        public byte IdSort { get; set; }
        public int? IdFilter { get; set; }
        public string NameFilter { get; set; }
        public byte NameSort { get; set; }
        public byte DateOfBirthSort { get; set; }
        public DateTime? DateOfBirthFilter { get; set; }
        public byte MarriedSort { get; set; }
        public bool? MarriedFilter { get; set; }
        public string Phone { get; set; }
        public byte SalarySort { get; set; }
        public decimal? SalaryFilter { get; set; }
    }
}

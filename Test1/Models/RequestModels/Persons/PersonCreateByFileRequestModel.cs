using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Models.RequestModels.Persons
{
    public class PersonCreateByFileRequestModel
    {
        public IFormFile File{ get; set; }
    }
}

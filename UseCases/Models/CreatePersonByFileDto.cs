﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Models
{
    public class CreatePersonByFileDto
    {
        public IFormFile File { get; set; }

    }
}

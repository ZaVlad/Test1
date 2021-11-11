using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Persons.Command.Create
{
    public class CreatePersonCommand:IRequest<bool>
    {
        public CreatePersonByFileDto FileWithPeople { get; set; }
    }
}

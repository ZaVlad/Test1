using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Persons.Command.Create
{
    class CreateOrderCommandHandler : IRequestHandler<CreatePersonCommand,bool>
    {
        private readonly IDbContext _dbContext;
        public CreateOrderCommandHandler( IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            byte[] array = new byte[request.FileWithPeople.File.Length];
            request.FileWithPeople.File.OpenReadStream().Read(array, 0, array.Length);
            string fileString = System.Text.Encoding.Default.GetString(array);
            string[] peopleStrings = fileString.Split("\r\n");
            var people = new List<Person>();
            foreach (var item in peopleStrings)
            {
                string[] person = item.Split(';');
                if (int.TryParse(person[0], out int variable) == false)
                {
                    continue;
                }
                people.Add(
                    new Person()
                    {
                        Name = person[1],
                        DateOfBirth = DateTime.Parse(person[2]),
                        Married = bool.Parse(person[3].ToLower()),
                        Phone = person[4],
                        Salary = decimal.Parse(person[5].Replace('.', ','))
                    }); ;
            }
            await _dbContext.Person.AddRangeAsync(people);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases.Persons.Queries.GetList
{
    public class GetPeopleListQueryHandler : IRequestHandler<GetPeopleListQuery, ICollection<PersonDto>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPeopleListQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<PersonDto>> Handle(GetPeopleListQuery request, CancellationToken cancellationToken)
        {
            var people = _dbContext.Person.AsQueryable();
            if (request != null)
            {
                GetFilterAndSort(people, request);
            }
            return  _mapper.Map<List<PersonDto>>(await people.ToListAsync());

        }

        private void GetFilterAndSort(IQueryable<Person> queryable, GetPeopleListQuery filterSortModel)
        {
            if (filterSortModel.DateOfBirthFilter != null)
            {
                queryable = queryable.Where(c => c.DateOfBirth == filterSortModel.DateOfBirthFilter);
            }
            if (filterSortModel.IdFilter != null)
            {
                queryable = queryable.Where(c => c.Id == filterSortModel.IdFilter);
            }
            if (filterSortModel.MarriedFilter != null)
            {
                queryable = queryable.Where(c => c.Married == filterSortModel.MarriedFilter);
            }
            if (filterSortModel.NameFilter != null)
            {
                queryable = queryable.Where(c => c.Name == filterSortModel.NameFilter);
            }

            if (filterSortModel.Phone != null)
            {
                queryable = queryable.Where(c => c.Phone == filterSortModel.Phone);
            }

            if (filterSortModel.SalaryFilter != null)
            {
                queryable = queryable.Where(c => c.Salary == filterSortModel.SalaryFilter);
            }

            if (filterSortModel.DateOfBirthSort != 0)
            {
                queryable = filterSortModel.DateOfBirthSort == 1 ?
                    queryable.OrderBy(s => s.DateOfBirth) :
                    queryable.OrderByDescending(s => s.DateOfBirth);
            }
            else if (filterSortModel.IdSort != 0)
            {
                queryable = filterSortModel.IdSort == 1 ?
                  queryable.OrderBy(s => s.Id) :
                  queryable.OrderByDescending(s => s.Id);
            }
            else if (filterSortModel.MarriedSort != 0)
            {
                queryable = filterSortModel.MarriedSort == 1 ?
                  queryable.OrderBy(s => s.Married) :
                  queryable.OrderByDescending(s => s.Married);
            }
            else if (filterSortModel.NameSort != 0)
            {
                queryable = filterSortModel.NameSort == 1 ?
                  queryable.OrderBy(s => s.Name) :
                  queryable.OrderByDescending(s => s.Name);
            }
            else if (filterSortModel.SalarySort != 0)
            {
                queryable = filterSortModel.SalarySort == 1 ?
                  queryable.OrderBy(s => s.Salary) :
                  queryable.OrderByDescending(s => s.Salary);
            }
        }
    }
}

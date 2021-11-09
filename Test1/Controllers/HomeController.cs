using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;
using Test1.Models.RequestModels.Persons;
using UseCases.Persons.Queries.GetList;

namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISender _sender;
        public HomeController(ISender sender)
        {
            _sender = sender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetList([FromQuery]PersonFilterRequestModel person)
        {
            var people = await _sender.Send(ConvertToGetPeopleListQuery(person));
            ViewBag.IdSort = person.IdSort;
            ViewBag.NameSort = person.NameSort;
            ViewBag.DateOfBirthSort = person.DateOfBirthSort;
            ViewBag.MarriedSort = person.MarriedSort;
            ViewBag.SalarySort = person.SalarySort;
            return View(people);
        }

        private GetPeopleListQuery ConvertToGetPeopleListQuery(PersonFilterRequestModel person) 
        {
            return new GetPeopleListQuery()
            {
                DateOfBirthFilter = person.DateOfBirthFilter,
                DateOfBirthSort = person.DateOfBirthSort,
                IdFilter = person.IdFilter,
                IdSort = person.IdSort,
                MarriedFilter = person.MarriedFilter,
                MarriedSort = person.MarriedSort,
                NameFilter = person.NameFilter,
                NameSort = person.NameSort,
                Phone = person.Phone,
                SalaryFilter = person.SalaryFilter,
                SalarySort = person.SalarySort
            };
        }
    }
}

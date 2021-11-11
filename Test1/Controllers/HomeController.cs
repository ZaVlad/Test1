using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;
using Test1.Models.RequestModels.Persons;
using UseCases.Models;
using UseCases.Persons.Command.Create;
using UseCases.Persons.Queries.GetList;

namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISender _sender;
        static readonly string correctExtension = ".csv";
        public HomeController(ISender sender)
        {
            _sender = sender;
        }

        // GET: /Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/GetList
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PersonFilterRequestModel person)
        {
            var people = await _sender.Send(ConvertToGetPeopleListQuery(person));
            SetViewBag(person);


            return View(people);
        }

        //GET: /Home/Create
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateByFileRequestModel fileWithPeople)
        {
            if (ModelState.IsValid == false)
            {
                return View(fileWithPeople);
            }

            if (fileWithPeople.File is null)
            {
                ModelState.AddModelError($"{nameof(fileWithPeople.File)}", "You have to upload some file");
                return View(fileWithPeople);
            }
            var extension = Path.GetExtension(fileWithPeople.File.FileName);

            if(extension.ToLower() != correctExtension)
            {
                ModelState.AddModelError($"{nameof(fileWithPeople.File)}", "You have gave wrong type of file, try file with csv extension");
                return View(fileWithPeople);
            }
           var result = await _sender.Send(new CreatePersonCommand() 
            { FileWithPeople = new CreatePersonByFileDto() { 
                File = fileWithPeople.File} });

            if(result == false)
            {
                ModelState.AddModelError($"{nameof(fileWithPeople.File)}", "Something went wrong with proccessing data from file");
                return View(fileWithPeople);
            }

            return RedirectToAction("Index");
        }

        private void SetViewBag(PersonFilterRequestModel person)
        {
            ViewBag.IdSort = person.IdSort;
            ViewBag.NameSort = person.NameSort;
            ViewBag.DateOfBirthSort = person.DateOfBirthSort;
            ViewBag.MarriedSort = person.MarriedSort;
            ViewBag.SalarySort = person.SalarySort;
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

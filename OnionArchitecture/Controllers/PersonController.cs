using Data;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Models;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionArchitecture.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelList = new List<PersonVM>();
            var personList = await _personService.GetAllPersons();

            personList.ForEach(x =>
            {
                modelList.Add(new PersonVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    Address = x.Address
                });
            });

            return View(modelList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonVM personVM)
        {
            var person = new Person
            {
                FirstName = personVM.FirstName,
                LastName = personVM.LastName,
                DateOfBirth = personVM.DateOfBirth,
                Address = personVM.Address
            };

            await _personService.AddPerson(person);

            if (person.Id > 0)
            {
                return RedirectToAction("Index");
            }

            return View(personVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(new PersonVM
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Address = person.Address
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(new PersonVM
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Address = person.Address
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonVM personVM)
        {
            var person = await _personService.GetPersonById(personVM.Id);

            person.FirstName = personVM.FirstName;
            person.LastName = personVM.LastName;
            person.DateOfBirth = personVM.DateOfBirth;
            person.Address = personVM.Address;

            if (await _personService.UpdatePerson(person) > 0)
            {
                return RedirectToAction("Index");
            }

            return View(personVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(new PersonVM
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Address = person.Address
            }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (await _personService.RemovePerson(person) > 0)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }
    }
}

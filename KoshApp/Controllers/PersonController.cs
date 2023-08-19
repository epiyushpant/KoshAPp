using KoshApp.Models;
using KoshApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KoshApp.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _iPersonRepository;
        public PersonController(IPersonRepository iPersonRepository)
        {
            _iPersonRepository = iPersonRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _iPersonRepository.GetAllAsync();
            return View(result);
        }
        public async Task<IActionResult> Details(Int64 id)
        {
            var result = await _iPersonRepository.GetByIdAsync(id);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person Person)
        {
            if (ModelState.IsValid)
            {
                Person.CreatedDate = DateTime.Now;
                Person.UpdatedDate = DateTime.Now;
                //if (Person.Photo != null)
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //    }
                //}
                await _iPersonRepository.Create(Person);
                return RedirectToAction(nameof(Index));
            }
            return View(Person);
        }
        public async Task<IActionResult> Edit(Int64 id)
        {
            var _Person = await _iPersonRepository.GetByIdAsync(id);
            return View(_Person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Person Person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Person.Id = id;
                    Person.UpdatedDate = DateTime.Now;
                    await _iPersonRepository.Update(Person);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Person);
        }
        public async Task<IActionResult> Delete(Int64 id)
        {
            var _Person = await _iPersonRepository.GetByIdAsync(id);
            return View(_Person);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Int64 id)
        {
            await _iPersonRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
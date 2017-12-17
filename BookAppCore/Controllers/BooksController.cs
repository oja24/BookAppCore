using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookAppCore.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookAppCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAppCore.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repo;

        public BooksController(IBookRepository _repo) { repo = _repo; }


        public IActionResult Index()
        {
            var q =  repo.Books;

            return View(q);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Genre = new SelectList(repo.Books.Select(p => p.Genre).Distinct());

            return View(repo.Books.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.SaveMovie(book);
                TempData["message"] = $"{book.Title} has been saved";
                return  RedirectToAction("Index");
            } else
            {
                return View(book);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Book());
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = repo.DeleteMovie(id);
            if(book != null)
            {
                ViewBag.Message = $"{book.Title} has beed deleted";

                
            }

           return RedirectToAction("Index");
        }

        
    }
}

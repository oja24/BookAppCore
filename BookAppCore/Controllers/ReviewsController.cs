using Microsoft.AspNetCore.Mvc;
using BookAppCore.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookAppCore.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAppCore.Controllers
{
    public class ReviewsController : Controller
    {
        private BookDbContext context;
        private IBookRepository repo;
        private IReviewRepository Rrepo;

        public ReviewsController(IBookRepository _repo, IReviewRepository _Rrepo, BookDbContext _context)
        {
            repo = _repo;
            Rrepo = _Rrepo;
            context = _context;
        }

        public IActionResult Index([Bind(Prefix ="id")]int Bookid)
        {

            var review = repo.Books.Include(r => r.Reviews).SingleOrDefault(d => d.Id == Bookid);
                
            if(review == null)
            {
                return NotFound();
                
            }

            return View(review);
        }

        [HttpGet]
        public IActionResult Edit(int Bookid)
        {
            
            var q = context.Reviews.Find(Bookid);
            return View(q);
        }


        [HttpPost]
        public IActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                // context.Reviews.Add(review);
                context.Entry(review).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index", new { id = review.BookId });
            }
           
                return View(review);
            
        }



        public IActionResult Create(int BookId)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review view)
        {
            if (ModelState.IsValid)
            {
                context.Reviews.Add(view);
                context.SaveChanges();
                return RedirectToAction("Index", new { id = view.BookId });
            }
            return View(view);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}

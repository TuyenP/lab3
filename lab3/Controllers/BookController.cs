using lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.books.ToList();
            return View(listBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.books.SingleOrDefault(p => p.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Book book)
        {
            try
            {
                using (BookManagerContext a = new BookManagerContext())
                {
                    a.books.Add(book);
                    a.SaveChanges();

                }
                return RedirectToAction("ListBook");
            }


            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            using (BookManagerContext a = new BookManagerContext())
            {
                return View(a.books.Where(Medol => Medol.Id == Id).FirstOrDefault());
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int Id, Book book)
        {
            try
            {
                using (BookManagerContext a = new BookManagerContext())
                {
                    a.Entry(book).State = EntityState.Modified;
                    a.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            using (BookManagerContext a = new BookManagerContext())
            {
                return View(a.books.Where(Medol => Medol.Id == Id).FirstOrDefault());
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            try
            {
                using (BookManagerContext a = new BookManagerContext())
                {
                    Book sach = a.books.Where(Medol => Medol.Id == Id).FirstOrDefault();
                    a.books.Remove(sach);
                    a.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
            catch
            {
                return View();
            }
        }
    }
}
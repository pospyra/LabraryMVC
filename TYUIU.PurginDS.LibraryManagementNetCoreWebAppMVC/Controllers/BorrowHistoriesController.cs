using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models;

namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Controllers
{
    public class BorrowHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BorrowHistories
        public ActionResult Index()
        {
            var borrowHistories = db.BorrowHistories.Include(b => b.Book).Include(b => b.Customer);
            return View(borrowHistories.ToList());
        }

        // GET: BorrowHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            if (borrowHistory == null)
            {
                return HttpNotFound();
            }
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Create
        public ActionResult Create(int? selectedBookId)
        {
            var books = db.Books.ToList();
            ViewBag.BookId = new SelectList(books, "BookId", "Title", selectedBookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: BorrowHistories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BorrowHistory borrowHistory)
        {
            var isExistingHistory = db.BorrowHistories
                .Any(x=> x.CustomerId == borrowHistory.CustomerId && x.BookId == borrowHistory.BookId && x.ReturnDate == null);

            if (isExistingHistory)
            {
                ModelState.AddModelError("BookId", "Пользователь уже взял эту книгу.");
            }

            if (ModelState.IsValid && !isExistingHistory)
            {
                borrowHistory.BorrowDate = DateTime.UtcNow;
                db.BorrowHistories.Add(borrowHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // GET: BorrowHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            if (borrowHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BorrowHistory borrowHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", borrowHistory.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", borrowHistory.CustomerId);
            return View(borrowHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnBook(int bookId, int userId)
        {
            var borrowHistory = db.BorrowHistories
                .FirstOrDefault(b => b.BookId == bookId && 
                b.CustomerId == userId &&
                b.ReturnDate == null);

            if (borrowHistory != null)
            {
                borrowHistory.ReturnDate = DateTime.UtcNow;
                db.Entry(borrowHistory).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index"); // Или другое действие в случае неудачи
        }


        // GET: BorrowHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            if (borrowHistory == null)
            {
                return HttpNotFound();
            }
            return View(borrowHistory);
        }

        // POST: BorrowHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowHistory borrowHistory = db.BorrowHistories.Find(id);
            db.BorrowHistories.Remove(borrowHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

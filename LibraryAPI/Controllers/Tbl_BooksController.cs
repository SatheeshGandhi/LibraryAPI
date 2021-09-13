using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    public class Tbl_BooksController : ApiController
    {
        private APILibraryEntities db = new APILibraryEntities();

        // GET: api/Tbl_Books
        public IQueryable<Tbl_Books> GetTbl_Books()
        {
            return db.Tbl_Books;
        }

        // GET: api/Tbl_Books/5
        [ResponseType(typeof(Tbl_Books))]
        public IHttpActionResult GetTbl_Books(int id)
        {
            Tbl_Books tbl_Books = db.Tbl_Books.Find(id);
            if (tbl_Books == null)
            {
                return NotFound();
            }

            return Ok(tbl_Books);
        }

        // PUT: api/Tbl_Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Books(int id, Tbl_Books tbl_Books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Books.BookId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Books).State = EntityState.Modified;

            try
            {
                tbl_Books.IsActive = 1;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tbl_Books
        [ResponseType(typeof(Tbl_Books))]
        public IHttpActionResult PostTbl_Books(Tbl_Books tbl_Books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tbl_Books.IsActive = 1;
            db.Tbl_Books.Add(tbl_Books);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Books.BookId }, tbl_Books);
        }

        // DELETE: api/Tbl_Books/5
        [ResponseType(typeof(Tbl_Books))]
        public IHttpActionResult DeleteTbl_Books(int id)
        {
            Tbl_Books tbl_Books = db.Tbl_Books.Find(id);
            if (tbl_Books == null)
            {
                return NotFound();
            }

            tbl_Books.IsActive = 0;
            db.SaveChanges();

            return Ok(tbl_Books);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_BooksExists(int id)
        {
            return db.Tbl_Books.Count(e => e.BookId == id) > 0;
        }
    }
}
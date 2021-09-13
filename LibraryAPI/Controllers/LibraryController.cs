using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LibraryAPI.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index(int? i)
        {
            IEnumerable<Books> BooksList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Tbl_Books").Result;
            BooksList = response.Content.ReadAsAsync<IEnumerable<Books>>().Result;
            return View(BooksList.Where(x => x.IsActive == 1).ToList().ToPagedList(i ?? 1, 4));
        }

        public ActionResult Add()
        {
            return View(new Books());
        }
        [HttpPost]
        public ActionResult Add(Books newbook)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Tbl_Books", newbook).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Tbl_Books/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Books>().Result);

        }
        [HttpPost]
        public ActionResult Edit(Books newbook)
        {
            if (newbook.BookId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Tbl_Books", newbook).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Tbl_Books/" + newbook.BookId, newbook).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Tbl_Books/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Removed Successfully";
            return RedirectToAction("Index");
        }
    }
}
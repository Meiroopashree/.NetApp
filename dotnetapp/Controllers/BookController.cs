using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotnetapp.Models;
using dotnetapp.Repositories.Abstract;

namespace dotnetapp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult Add()
        {
            var model = new Book();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var model = bookService.FindById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            var result = bookService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = bookService.GetAll();
            return View(data);
        }
    }
}
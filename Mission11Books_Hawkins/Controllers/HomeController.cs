using Microsoft.AspNetCore.Mvc;
using Mission11Books_Hawkins.Models;
using Mission11Books_Hawkins.Models.ViewModels;
using System.Diagnostics;

namespace Mission11Books_Hawkins.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepo;

        public HomeController(IBookRepository temp)
        {
            _bookRepo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var blah = new BooksListViewModel
            {
                Books = _bookRepo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepo.Books.Count()
                }
            };

            return View(blah);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

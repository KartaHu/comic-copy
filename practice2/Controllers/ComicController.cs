using practice2.Models;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace practice.Controllers
{
    public class ComicController : Controller
    {
        private practice2Entities2 _context;
        public ComicController()
        {
            _context = new practice2Entities2();
        }

        private int pageSize = 36;
        // GET: Comic
        public ViewResult Index(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            var comic = _context.practice2.OrderBy(x => x.title);
            var result = comic.ToPagedList(currentPage, pageSize);
            return View(result);
        }
        public ActionResult Details(string title)
        {
        var comic = _context.practice2.SingleOrDefault(c => c.title == title);

        if (comic == null)
            return HttpNotFound();


        return View(comic);
        }
        
    }
}
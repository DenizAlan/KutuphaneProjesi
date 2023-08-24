using System.Linq;
using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YayinEviController: Controller
    {
        private readonly KutuphaneContext _context;
        public YayinEviController(KutuphaneContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.YayinEvleri.ToList());
        }

        //public IActionResult Add()
        //{
        //    return View();
        //}
        //[HttpPost]

        //public IActionResult Add(YayinEvi yayinEvi) 
        //{
        //    _context.YayinEvleri.Add(yayinEvi);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult Delete(int id)
        {
            _context.YayinEvleri.Remove(_context.YayinEvleri.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult UpSert(int? id)
		{
			if (id == 0)
			{
				return View();
			}
            else
            {
				return View(_context.YayinEvleri.Find(id));
			}
			
		}
        [HttpPost]
		public IActionResult UpSert(YayinEvi yayinEvi)
		{
            if (yayinEvi != null)
            {
				if (yayinEvi.Id == 0)
				{
					_context.YayinEvleri.Add(yayinEvi);

				}
				else
				{
					_context.YayinEvleri.Update(yayinEvi);

				}
				_context.SaveChanges();
			}
		
			return RedirectToAction("Index");
		}


		//public IActionResult Update (int id)
  //      {
  //          return View(_context.YayinEvleri.Find(id));
  //      }
  //      [HttpPost]

  //      public IActionResult Update(YayinEvi yayinEvi)
  //      {
  //          _context.YayinEvleri.Update(yayinEvi);
  //          _context.SaveChanges();
  //          return RedirectToAction("Index");
  //      }
    }
}

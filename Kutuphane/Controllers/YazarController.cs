using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        //Dependency Injection
        private readonly KutuphaneContext _context;

        public YazarController(KutuphaneContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<Yazar> yazarlar=_context.Yazarlar.ToList<Yazar>();

            //2.yol
            return View(_context.Yazarlar.ToList<Yazar>());
        }

        //public IActionResult Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Add(Yazar yazar)
        //{
        //    _context.Yazarlar.Add(yazar);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult Delete(int id)
        {
            //1.yol
            //Yazar yazar= _context.Yazarlar.Find(id);
            //_context.Yazarlar.Remove(yazar);

            //Bu yol uzun kullanma
            //Yazar yazar = _context.Yazarlar.Where(y=>y.Id == id).First(); //Bir serinin-dizinin ilk elementi isteme

            //
            //Yazar yazar1 = _context.Yazarlar.FirstOrDefault(y => y.Id == id); //O kritere uyan birden fazla şey olsa bile ilk yakaladıgını getiriyor sana 

            //Kısa yol //En iyi yol
            _context.Yazarlar.Remove(_context.Yazarlar.Find(id));

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult Update(int id)
        //{
        //    return View(_context.Yazarlar.Find(id));
        //}

        public IActionResult UpSert(int? id)
        {
            if (id!=null)
            {
                return View(_context.Yazarlar.Find(id));
            }
            else
            {
				return View();
			}
          
        }
        [HttpPost]
        public IActionResult UpSert(Yazar yazar)
        {
            if (yazar.Id == 0)
            {
                _context.Yazarlar.Add(yazar);
                _context.SaveChanges();
            }
            else
            {
                _context.Yazarlar.Update(yazar);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Update(Yazar yazar)
        //{
        //    _context.Yazarlar.Update(yazar);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        
    }
}

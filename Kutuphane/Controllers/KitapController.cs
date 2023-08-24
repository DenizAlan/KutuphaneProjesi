using System.Reflection;
using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Controllers
{
	public class KitapController : Controller
	{
		private readonly KutuphaneContext _context;

		public KitapController(KutuphaneContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			//_context.Kitaplar.Select(k=> new
			//{
			//    k.Id,
			//    k.Ad,
			//    k.Yazarlar,
			//    k.YayinEvleri,

			//})


			return View(_context.Kitaplar.Include(k => k.YayinEvleri).Include(k => k.Yazarlar).ToList());
		}

		public IActionResult Add()
		{
			
			ViewData["Yazarlar"] = _context.Yazarlar.ToList();
			ViewData["YayinEvleri"] = _context.YayinEvleri.ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Add(Kitap kitap, List<string> yazarlar, List<string>yayinEvleri)
		{
			foreach (string s in yazarlar)
				kitap.Yazarlar.Add(_context.Yazarlar.Find(int.Parse(s)));
			
			foreach (string s in yayinEvleri)
				kitap.YayinEvleri.Add(_context.YayinEvleri.Find(int.Parse(s)));
			
			_context.Kitaplar.Add(kitap);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}

		public IActionResult Update(int id)
		{
			ViewData["Yazarlar"] = _context.Yazarlar.ToList();
			ViewData["YayinEvleri"] = _context.YayinEvleri.ToList();

			return View(_context.Kitaplar.Include(k=>k.Yazarlar).Include(k=>k.YayinEvleri).FirstOrDefault(k=>k.Id==id));
		}

		public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
		{
			Kitap asil = _context.Kitaplar.Include(k=>k.YayinEvleri).Include(k=>k.Yazarlar).FirstOrDefault(k=>k.Id==kitap.Id);
			asil.Ad=kitap.Ad;
			asil.ISBN=kitap.ISBN;

			List<Yazar>YazarListesi= new List<Yazar>();
			List<YayinEvi>YayinEvleriListesi= new List<YayinEvi>();

			foreach (int s in yazarlar)
				YazarListesi.Add(_context.Yazarlar.Find(s));

			foreach (int s in yayinEvleri)
				YayinEvleriListesi.Add(_context.YayinEvleri.Find(s));

			asil.Yazarlar = YazarListesi;
			asil.YayinEvleri= YayinEvleriListesi;

			_context.Kitaplar.Update(asil);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}

	}
}

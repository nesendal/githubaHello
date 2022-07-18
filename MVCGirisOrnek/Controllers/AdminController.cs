using Microsoft.AspNetCore.Mvc;
using MVCGirisOrnek.Models;
using System.Linq;

namespace MVCGirisOrnek.Controllers
{
    public class AdminController : Controller
    {
        UyeDBContext veritabani = new UyeDBContext();

        public IActionResult Index()
        {
            return View();
        }

        //uyeEkle olsun
        //geriye string dönen bir metot yaazalım.
        //public string UyeEkle()
        //{
        //    return "Uye eklenecek";
        //}

        //uyeEkle sayfasını gözümüze açması için, o sayfayı yüklemesi için
        public IActionResult UyeEkle()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult UyeEkle(Uye uye)
        {
            veritabani.Uyes.Add(uye);
            veritabani.SaveChanges();
            return View();
        }

        public IActionResult Uyeler()
        {
            var liste = veritabani.Uyes.ToList();
            return View(liste);
        }

        //uye düzenleme
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = veritabani.Uyes.Find(id);
            if (uye == null)
            {
                return NotFound();
            }
            return View(uye);
        }

        [HttpPost]
        public IActionResult Edit(int id,Uye uye)
        {
            if (id != uye.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                veritabani.Update(uye);
                veritabani.SaveChanges();

                return RedirectToAction(nameof(Uyeler)); 
                //düzenleme işlemi sonrası uyeler listesine ddönsün diye redirecttoAction diyip uyeler sayfasına gönderilir.
            }
            return View(uye);
        }


        // GET: Uyes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye =  veritabani.Uyes.FirstOrDefault(m => m.Id == id);
            if (uye == null)
            {
                return NotFound();
            }

            return View(uye);
        }



        // POST: Uyes/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var uye =  veritabani.Uyes.Find(id);            
            veritabani.Uyes.Remove(uye);
            veritabani.SaveChanges();
            return RedirectToAction(nameof(Uyeler));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = veritabani.Uyes.Find(id);
            if (uye == null)
            {
                return NotFound();
            }
            return View(uye);
        }
    }
}

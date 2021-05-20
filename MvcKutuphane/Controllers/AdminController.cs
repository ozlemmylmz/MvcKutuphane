using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        DBKUTUPHANEEntities3 db = new DBKUTUPHANEEntities3();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.KULLANİCİ ==p.KULLANİCİ
            && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANİCİ , false);
                Session["KULLANİCİ"] = bilgiler.KULLANİCİ.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}
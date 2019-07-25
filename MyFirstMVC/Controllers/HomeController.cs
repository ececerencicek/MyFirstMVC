using MyFirstMVC.Data;
using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "MVC Projem.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Aşağdaki formu doldurarak benimle iletişim kurabilirsiniz.";

            return View();
        }

        //form post edildiği zaman burası çalışır.
        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            //serverda validasyon yapmayı sağlar. Javascriptle bir validasyon yapılıyor ama burada da ikinci bir validasyon yapıyoruz.
            //javascriptin çalışmasına izin verilmediği durumlarda serverda yapılan bu validasyon çalışır.
            //bankayla ilgili durumlarda serverda validasyon yaparız. O açıdan da gereklidir.
          
                if (ModelState.IsValid)
                {
                try
                {
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

                    mailMessage.From = new System.Net.Mail.MailAddress("ccrncck@gmail.com", "Ece");
                    mailMessage.Subject = "İletişim Formu: " + model.FirstName + " " + model.LastName;

                    mailMessage.To.Add("ccrncck@gmail.com");

                    string body;
                    body = "Ad : " + model.FirstName + "<br />";
                    body += "Soyad : " + model.LastName + "<br />";
                    body += "Telefon: " + model.Phone + "<br />";
                    body += "E-posta: " + model.Email + "<br />";
                    body += "Mesaj: " + model.Message + "<br />";
                    body += "Tarih: " + DateTime.Now.ToString("dd MMMM yyyy HH:mm") + "<br />";

                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    //giriş yapılıyor
                    smtp.Credentials = new System.Net.NetworkCredential("ccrncck@gmail.com", "parola");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
                }
                catch (Exception ex)
                    {
                        ViewBag.Error = "Form gönderimi başarısız oldu. Lütfen daha sonra tekrar deneyiniz.";
                    }
                }
                
                 //validasyon başarılı değilse form tekrar görüntülenip hata mesajları gösterilecek
                 //model yazıldığında dolu gelmesini sağlar.
                 return View(model);
        }

        public ActionResult Project()
        {
           using (var db = new ApplicationDbContext())
            {
                //içinde proje nesneleri var
                var projects = db.Projects.ToList();
                return View(projects);
            }

        }

        public ActionResult Kvkk()
        {
            return View();
        }

        public ActionResult Cookie()
        {
            return View();
        }
    }
}
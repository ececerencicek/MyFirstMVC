﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Areas.Admin.Controllers
{
    //iki tane controller var. Karışmaması için bunu yazıyoruz. Admin içibdeki controller anlamında
    [RouteArea("Admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
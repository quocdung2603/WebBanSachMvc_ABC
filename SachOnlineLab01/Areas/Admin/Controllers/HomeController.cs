﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnlineLab01.Models;
namespace SachOnlineLab01.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        SachOnlineEntities db = new SachOnlineEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if(Session["Admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var sTenDN = f["Username"];
            var sMatKhau = f["Password"];

            ADMIN ad = db.ADMINs.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau);

            if(ad != null)
            {
                Session["Admin"] = ad;
                return RedirectToAction("Index");
            } else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                
            }

            return View();
        }
    }
}
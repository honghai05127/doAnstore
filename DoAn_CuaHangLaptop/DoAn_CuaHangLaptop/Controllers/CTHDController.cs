using DoAn_CuaHangLaptop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class CTHDController : Controller
    {
        // GET: CTHDController
        public ActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layCTHD());
        }

        // GET: CTHDController/Details/5
        public ActionResult Details(string mahd, string masp)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinCTHD(mahd,masp));
        }

        // GET: CTHDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTHDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CTHD cthd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(cthd);
            }
            if (context.taoCTHD(cthd) != 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CTHDController/Edit/5
        public ActionResult Edit(string mahd, string masp)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinCTHD(mahd,masp));
        }

        // POST: CTHDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string mahd, string masp, CTHD cthd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (context.capNhatCTHD(cthd) != 0)
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            return View(cthd);
        }

        
        // POST: CTHDController/Delete/5
        
        public ActionResult Delete(string mahd, string masp, CTHD cthd)
        {

                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
                context.xoaHoaDon(mahd);
                return RedirectToAction("Index");

            
        }
    }
}

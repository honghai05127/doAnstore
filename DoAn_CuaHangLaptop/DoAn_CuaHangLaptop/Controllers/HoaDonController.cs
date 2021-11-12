using DoAn_CuaHangLaptop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDonController
        public ActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layHoaDon());
        }

        // GET: HoaDonController/Details/5
        public ActionResult Details(string mahd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinHD(mahd));
        }

        // GET: HoaDonController/Create
        public ActionResult Create()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            
            ViewBag.dsNV = context.layNhanVien();

            return View();
        }

        // POST: HoaDonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HoaDon hd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(hd);
            }
            if (context.taoHoaDon(hd) == 0)
            {
                ModelState.AddModelError("", "Ngày hóa đơn phải trước ngày hôm nay");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(hd);
         
          
        }

        // GET: HoaDonController/Edit/5
        public ActionResult Edit(string mahd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinHD(mahd));
        }

        // POST: HoaDonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string mahd, HoaDon hd)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (context.capNhatHoaDon(hd) != 0)
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            return View(hd);
        }

       

        // POST: HoaDonController/Delete/5
       
        public ActionResult Delete(string mahd, HoaDon hd)
        {

            try
            {

                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
                context.xoaHoaDon(mahd);
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index");

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                TempData["AlertMessage"] = "Tồn tại CTHD của HD này. Không thể xóa";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction("Index");
            }
        }
    }
}

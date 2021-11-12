using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_CuaHangLaptop.Models;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoanController
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layTaiKhoan());
        }

        // GET: TaiKhoanController/Details/5
        public ActionResult Details(string tendangnhap)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinTK(tendangnhap));
        }

        // GET: TaiKhoanController/Create
        public ActionResult Create()
        {
            var model = new TaiKhoan();
            return View();
        }

        // POST: TaiKhoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaiKhoan tk)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(tk);
            }
            if (context.taoTaiKhoan(tk) == 0)
            {
                ModelState.AddModelError("", "Tên tài khoản đã tồn tại");
            }
            else
            {
                TempData["AlertMessage"] = "Thêm thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index");
            }


            return View(tk);
        }


        // GET: TaiKhoanController/Edit/5
        public ActionResult Edit(string tendangnhap)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinTK(tendangnhap));
        }

        // POST: TaiKhoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string tendangnhap, TaiKhoan tk)
        {
            
                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
                if (context.capNhatTaiKhoan(tk) != 0)
                {
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                    return RedirectToAction(nameof(Index));
              
                }
                return View(tk);
          
              
        }

        
        // POST: TaiKhoanController/Delete/5

        public ActionResult Delete(string tendangnhap, TaiKhoan tk)
        {
            try
            {

               LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
                context.xoaTaiKhoan(tendangnhap);
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index");
          
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                TempData["AlertMessage"] = "Tồn tại người dùng có tài khoản này. Không thể xóa";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction("Index");
            }

        }
    }
}

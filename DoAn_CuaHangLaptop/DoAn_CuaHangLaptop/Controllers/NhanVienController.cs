using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_CuaHangLaptop.Models;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layNhanVien());
        }
        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            var model = new NhanVien();
            return View();
        }

        // POST: NhanVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhanVien nv)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(nv);
            }
            if (context.taoNhanVien(nv) == 0)
            {
                ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
            }
            else
            {
                return RedirectToAction("Index");
            }


            return View(nv);
        }

        // GET: NhanVienController/Details/5
        
        public ActionResult Details(string manv)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext; 
            return View(context.layThongTinNV(manv));
        }
        // GET: NhanVienController/Edit/5
       
        public ActionResult Edit(string manv)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinNV(manv));
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string manv, NhanVien nvien)
        {
            try
            {
                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
                if(context.capNhatNhanVien(nvien) != 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

        // POST: NhanVienController/Delete/5
     
        public ActionResult Delete(string manv, NhanVien nv)
        {
            try
            {
                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;

                context.xoaNhanVien(manv);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           
                
         
          
        }
    }
}

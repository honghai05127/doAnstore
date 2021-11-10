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
            int temp = context.taoNhanVien(nv);
            if (!ModelState.IsValid)
            {
                return View(nv);
            }
            if (temp == 0)
            {
                ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
            }
            else if(temp == 2)
            {
                ModelState.AddModelError("", "Người lao động phải lớn hơn 16 tuổi");

            }
            else if (temp == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit", "TaiKhoan", new { tendangnhap = nv.TenDangNhap });

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
           
                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
                if(context.capNhatNhanVien(nvien) == 0)
                {
                    ModelState.AddModelError("", "Người lao động phải lớn hơn 16 tuổi");
                }
                else
                {
                    return RedirectToAction("Index");
                }
             
          
                return View(nvien);
           
        }

       

        // POST: NhanVienController/Delete/5
     
        public ActionResult Delete(string manv, string tendangnhap)
        {
            
                LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;

                context.xoaNhanVien(manv);
                context.xoaTaiKhoan(tendangnhap);
                return RedirectToAction(nameof(Index));

          
        }
    }
}

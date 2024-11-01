using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookASP.DataAccess.data;
using BookASP.DataAccess.Repository.IRepository;
using BookASP.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookASP.Model.ViewModel;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using BookASP.Utility;
using Microsoft.AspNetCore.Authorization;

namespace BookASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitofwork,IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            List<Product> objCategoryList = _unitofwork.Product.GetAll("Category").ToList();
            IEnumerable<SelectListItem> CategoryList = _unitofwork.Category.GetAll().Select(u=>new SelectListItem
            {
                Text =u.Name,
                Value=u.Id.ToString()
            });

            return View(objCategoryList);
        }

        public IActionResult Upsert(int?id) {
			IEnumerable<SelectListItem> CategoryList = _unitofwork.Category.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});
            ProductViewModel productVM = new ProductViewModel {
                CategoryList = CategoryList,
                product = new Product()
            };
	        if(id == null || id == 0)
            {
                //up
				return View(productVM);
			}
            else
            {
                // in
                productVM.product = _unitofwork.Product.Get(u => u.Id == id);
				return View(productVM);
			}
			
        }
        [HttpPost]
        public IActionResult Upsert(ProductViewModel productVM, IFormFile? file)
        {
           
            if (ModelState.IsValid)
            {
				//! lấy đường dẫn thư mục root
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{   // Tên mới và tệp mở rộng của file
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string ProductPath = Path.Combine(wwwRootPath, @"Image\Product");
                    if(!string.IsNullOrEmpty(productVM.product.ImageUrl)) {
                        var oldImage = Path.Combine(wwwRootPath, productVM.product.ImageUrl.TrimStart('\\'));
						// Kiểm tra xem tệp có tồn tại không và xóa nó nếu cần
						if (System.IO.File.Exists(oldImage))
						{
							System.IO.File.Delete(oldImage);
						}
					}
                    //! tạo ra file mới trên đường dẫn
					using (var fileStream = new FileStream(Path.Combine(ProductPath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					productVM.product.ImageUrl = @"\Image\Product\" + fileName;


				}
                else {
                    productVM.product.ImageUrl = "";
                }
                if(productVM.product.Id == 0) {
					_unitofwork.Product.Add(productVM.product);
				}
                else
                {
					_unitofwork.Product.update(productVM.product);
				}
				
                _unitofwork.save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");

            }
            else
            {
				IEnumerable<SelectListItem> CategoryList = _unitofwork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				});
			     productVM = new ProductViewModel
				{
					CategoryList = CategoryList,
					product = new Product()
				};

				return View(productVM);
			}

        }
       
        #region API CALLs
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            
            List<Product> products = _unitofwork.Product.GetAll("Category").ToList();
            return  Json(new { data = products });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Product? product = _unitofwork.Product.Get(u => u.Id == id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImage = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));
            // Kiểm tra xem tệp có tồn tại không và xóa nó nếu cần
            if (System.IO.File.Exists(oldImage))
            {
                System.IO.File.Delete(oldImage);
            }
            _unitofwork.Product.Remove(product);
            _unitofwork.save();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}

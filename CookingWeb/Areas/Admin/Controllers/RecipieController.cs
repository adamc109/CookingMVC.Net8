using Cooking.Models;
using Microsoft.AspNetCore.Mvc;
using Cooking.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cooking.Models.ViewModels;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace CookingWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipieController : Controller
    {
        //connect to data from Recipie using dbcontext
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RecipieController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Recipie> objRecipieList = _unitOfWork.Recipie.GetAll(includeProperties:"Category").ToList();

            return View(objRecipieList);

        }

        public IActionResult Upsert(int? id)
        {


   
            RecipieVM recipieVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                 Recipie = new Recipie()
            };
            if (id == null || id == 0)
            {
                return View(recipieVM);
            }
            else
            {
                //update
                recipieVM.Recipie = _unitOfWork.Recipie.Get(u=>u.Id == id);
                return View(recipieVM);
            }

            
        }
        [HttpPost]
        public IActionResult Upsert(RecipieVM recipieVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //file upload of image
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if(!string .IsNullOrEmpty(recipieVM.Recipie.ImageURL))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, recipieVM.Recipie.ImageURL.TrimStart('/'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using ( var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    recipieVM.Recipie.ImageURL = @"\images\product\" + fileName;
                }
                if(recipieVM.Recipie.Id == 0)
                {
                    _unitOfWork.Recipie.Add(recipieVM.Recipie);
                }
                else
                {
                    _unitOfWork.Recipie.Update(recipieVM.Recipie);
                }
                _unitOfWork.Save();
                TempData["success"] = "Recipie created sucessfully";
                return RedirectToAction("Index", "Recipie");
            }
            else
            {
               //Re populates dropdown
                recipieVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(recipieVM);
            }


        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Recipie> objRecipieList = _unitOfWork.Recipie.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = objRecipieList});
        }

        
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Recipie.Get(u=> u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting"});
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageURL.TrimStart('/'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Recipie.Remove(productToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Sucessful" });
        }
        #endregion
    }
}

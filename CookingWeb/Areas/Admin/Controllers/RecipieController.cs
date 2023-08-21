using Cooking.Models;
using Microsoft.AspNetCore.Mvc;
using Cooking.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cooking.Models.ViewModels;

namespace CookingWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipieController : Controller
    {
        //connect to data from Recipie using dbcontext
        private readonly IUnitOfWork _unitOfWork;
        public RecipieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Recipie> objRecipieList = _unitOfWork.Recipie.GetAll().ToList();

            return View(objRecipieList);

        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

   
            RecipieVM recipieVM = new()
            {
                CategoryList = CategoryList,
                Recipie = new Recipie()
            };


            return View(recipieVM);
        }
        [HttpPost]
        public IActionResult Create(RecipieVM recipieVM )
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Recipie.Add(recipieVM.Recipie);
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            //Recipie? RecipieFromDb = _db.Categories.Find(id);
            Recipie? RecipieFromDb = _unitOfWork.Recipie.Get(u=>u.Id==id);
            if (RecipieFromDb == null)
            {
                return NotFound();
            }
            return View(RecipieFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Recipie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Recipie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Recipie Updated Sucessfully";

                return RedirectToAction("Index");
            }
            else return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            Recipie? RecipieFromDb = _unitOfWork.Recipie.Get(u => u.Id == id);
            if (RecipieFromDb == null)
            {
                return NotFound();
            }
            return View(RecipieFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Recipie? obj = _unitOfWork.Recipie.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Recipie.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Recipie Deleted Sucessfully";
            return RedirectToAction("Index");
        }
    }
}

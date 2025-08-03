
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategorylist = _unitOfWork.Category.GetAll().ToList();
            return View(objCategorylist);
        }

       
        public IActionResult Create() 
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString()) 
            //{
            //    ModelState.AddModelError("name","the displyeorder can't match the name");
            //}
            if (ModelState.IsValid) 
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Sucsses"] = "Category Created Sucseccfuly";
                return RedirectToAction("Index");
            }
            return View();
        }
        //GetUpdate
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            { 
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u=>u.Id==id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            if (categoryFromDb == null) 
            { 
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "the displyeorder can't match the name");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["Sucsses"] = "Category Updated Sucseccfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GetDelete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u =>u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
             
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Sucsses"] = "Category Deleted Sucseccfuly";
                return RedirectToAction("Index");
            
           
        }
    }
}

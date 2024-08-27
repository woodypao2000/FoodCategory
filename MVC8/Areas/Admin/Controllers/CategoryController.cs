using Microsoft.AspNetCore.Mvc;
using MVC8.DataAccess.Data;
using MVC8.DataAccess.Repository;
using MVC8.DataAccess.Repository.IRepository;
using MVC8.Models;
namespace MVC8.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;     //宣告IUnitOfWork接口的私有字段 
        public CategoryController(IUnitOfWork unitOfWork)// 構造函數 接收 unitOfWork
        {
            _unitOfWork = unitOfWork;//將接受到的參數賦值給字段
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();

            return View(categories); //傳遞給前端

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View(); //傳遞給前端
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            if (category.Name.Length <= 5)
            {
                ModelState.AddModelError("Name", "長度不能小於5");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "新增成功";
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category); //傳遞給前端
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name.Length <= 5)
            {
                ModelState.AddModelError("Name", "長度不能小於5");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                TempData["EditSuccess"] = "編輯成功";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")] //再透過ActionName改回名字
        public IActionResult DeletePost(int? id)//由於參數一致所以無法使用多態 因此改名
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();
            TempData["DeleteSuccess"] = "刪除成功";
            return RedirectToAction("Index");

        }

    }
}

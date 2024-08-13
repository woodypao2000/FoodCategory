using Microsoft.AspNetCore.Mvc;
using MVC8.DataAccess.Data;
using MVC8.Models;
namespace MVC8.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; //宣告 ApplicationDbContext 類別的私有字段 
        public CategoryController(ApplicationDbContext db)// 構造函數 接收 ApplicationDbContext類別的參數
        { 
            _db = db;//將接受到的參數賦值給字段
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();

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
            
            if (category.Name.Length<=5) {
                ModelState.AddModelError("Name","長度不能小於5");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "新增成功";
                return RedirectToAction("Index");
               
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null) { 
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
                _db.Categories.Update(category);
                _db.SaveChanges();
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
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category); 
        }
        [HttpPost,ActionName("Delete")] //再透過ActionName改回名字
        public IActionResult DeletePost(int? id)//由於參數一致所以無法使用多態 因此改名
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["DeleteSuccess"] = "刪除成功";
            return RedirectToAction("Index");   

        }

    }
}

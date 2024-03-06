using Microsoft.AspNetCore.Mvc;
using SampleMVC.Models;

namespace SampleMVC.Controllers;

public class CategoriesController : Controller
{
    private static List<Category> categories = new List<Category>() {
        new Category { CategoryID = 1, CategoryName = "Beverages" },
        new Category { CategoryID = 2, CategoryName = "Condiments" },
        new Category { CategoryID = 3, CategoryName = "Confections" },
        new Category { CategoryID = 4, CategoryName = "Dairy Products" },
        new Category { CategoryID = 5, CategoryName = "Grains/Cereals" },
        new Category { CategoryID = 6, CategoryName = "Meat/Poultry" },
        new Category { CategoryID = 7, CategoryName = "Produce" }
    };

    public IActionResult Index()
    {
        ViewData["username"] = "ekurniawan";
        //ViewBag.username = "ekurniawan";
        ViewBag.role = "admin";

        return View(categories);
    }

    public IActionResult Detail(int id)
    {
        /*var category = (from c in categories
                        where c.CategoryID == id
                        select c).SingleOrDefault();*/
        var category = categories.SingleOrDefault(c => c.CategoryID == id);
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        categories.Add(category);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var editCategory = categories.SingleOrDefault(c => c.CategoryID == id);
        if (editCategory == null)
        {
            return NotFound();
        }
        return View(editCategory);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (category == null)
        {
            return BadRequest();
        }
        var editCategory = categories.SingleOrDefault(c => c.CategoryID == category.CategoryID);
        if (editCategory == null)
        {
            return NotFound();
        }
        editCategory.CategoryName = category.CategoryName;
        return RedirectToAction("Index");
    }
}

using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;

[BindProperties]
public class Create : PageModel
{
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }
    
    public Create(ApplicationDbContext db) { _db = db; }

    public void OnGet() { }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The name and display order cannot be the same.");
        }
        if (ModelState.IsValid)
        {
            await  _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Category created successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
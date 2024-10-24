﻿using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;

[BindProperties]
public class Edit : PageModel
{
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }
    
    public Edit(ApplicationDbContext db) { _db = db; }

    public void OnGet(int id)
    {
        Category = _db.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The name and display order cannot be the same.");
        }
        if (ModelState.IsValid)
        {
            _db.Category.Update(Category);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Category updated successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
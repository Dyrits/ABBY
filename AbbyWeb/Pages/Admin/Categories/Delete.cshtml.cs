﻿using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;

[BindProperties]
public class Delete : PageModel
{
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }
    
    public Delete(ApplicationDbContext db) { _db = db; }

    public void OnGet(int id)
    {
        Category = _db.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _db.Category.Remove(Category);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Category deleted successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
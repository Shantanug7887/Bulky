using BulkyWebRezor.Data;
using BulkyWebRezor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRezor.Pages.Categorise
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0) 
            {
                Category = _db.Categories.Find(id);                
            }


        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                //TempData["Sucsses"] = "Category Updated Sucseccfuly";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}

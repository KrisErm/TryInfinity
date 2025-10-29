using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TryThree.Helpers;

namespace TryThree.Pages.Products
{
    public class DeleteModel : PageModel
    {
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = FakeDB._products.FirstOrDefault(p => p.Id == id);
            if (Product == null)
            {
                TempData["Response"] = "Товар не найден!";
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var product = FakeDB._products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                FakeDB._products.Remove(product);
                TempData["Response"] = "Товар успешно удалён!";
            }
            else
            {
                TempData["Response"] = "Товар не найден!";
            }
            return RedirectToPage("Index");
        }
    }
}
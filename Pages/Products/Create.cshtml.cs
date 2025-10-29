using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TryThree.Helpers;

namespace TryThree.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; } = new Product();

        public IActionResult OnPost()
        {
            if (NewProduct.Price < 1000)
            {
                TempData["Response"] = "Ошибка: цена должна быть не меньше 1000!";
                return RedirectToPage("Index");
            }

            NewProduct.Id = FakeDB._products.Max(x => x.Id) + 1;
            FakeDB._products.Add(NewProduct);

            TempData["Response"] = "Товар успешно добавлен!";
            return RedirectToPage("Index");
        }
    }
}

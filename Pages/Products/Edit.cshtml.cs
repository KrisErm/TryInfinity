using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TryThree.Helpers;

namespace TryThree.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product MyProduct { get; set; } = new Product();

        public IActionResult OnGet(int id)
        {
            try
            {
                var product = FakeDB._products.FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    TempData["Response"] = "Товар не найден!";
                    return RedirectToPage("Index");
                }
                MyProduct = product;
                return Page();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                var product = FakeDB._products.FirstOrDefault(x => x.Id == MyProduct.Id);
                if (product == null)
                {
                    TempData["Response"] = "Товар не найден!";
                    return RedirectToPage("Index");
                }

                if (MyProduct.Price < 1000)
                {
                    TempData["Response"] = "Ошибка: цена должна быть не меньше 1000!";
                    return RedirectToPage("Index");
                }

                product.Name = MyProduct.Name;
                product.Price = MyProduct.Price;
                product.Quantity = MyProduct.Quantity;
                product.Color = MyProduct.Color;

                TempData["Response"] = "Товар успешно изменён!";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
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

        public void OnGet(int Id)
        {
            try
            {
                var product = FakeDB._products.FirstOrDefault(x => x.Id == Id);
                if (product == null)
                {
                    TempData["Response"] = "Товар не найден!";
                    return;
                }

                MyProduct = product;
            }
            catch (Exception ex)
            {
                TempData["Response"] = "Ошибка при загрузке товара!";
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
                TempData["Response"] = "Ошибка при сохранении товара!";
                throw ex;
            }
        }
    }
}
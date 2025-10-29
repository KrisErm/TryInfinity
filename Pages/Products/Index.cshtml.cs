using Microsoft.AspNetCore.Mvc.RazorPages;
using TryThree.Helpers;

namespace TryThree.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> ProductsList { get; set; } = new List<Product>();

        public void OnGet()
        {
            ProductsList = FakeDB._products;
        }
    }
}

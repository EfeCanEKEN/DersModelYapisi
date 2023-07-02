using Microsoft.AspNetCore.Mvc;
using DersModelYapisi.Models;

namespace DersModelYapisi.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            //  ProductViewModel 
            var product1 = new ProductViewModel { Id = 1, Name = "Laptop", Price = 23000.99m };
            var product2 = new ProductViewModel { Id = 2, Name = "Keyboard", Price = 799.99m };
            var product3 = new ProductViewModel { Id = 3, Name = "Mouse", Price = 789.99m };

            //  CartProductViewModel 
            var cartProduct1 = new CartProductViewModel
            {
                Id = 1,
                Product = product1,
                Quantity = 5,
                Price = product1.Price,  
                TotalPrice = 0,
                Tax = 0,
                TotalPriceWithTax = 0,
                TotalProduct = 0
            };
            var cartProduct2 = new CartProductViewModel
            {
                Id = 2,
                Product = product2,
                Quantity = 3,
                Price = product2.Price,
                TotalPrice = 0,
                Tax = 0,
                TotalPriceWithTax = 0,
                TotalProduct = 0
            };
            var cartProduct3 = new CartProductViewModel
            {
                Id = 3,
                Product = product3,
                Quantity = 2,
                Price = product3.Price,
                TotalPrice = 0,
                Tax = 0,
                TotalPriceWithTax = 0,
                
            };

            cartProduct1.TotalProduct = cartProduct1.Price * cartProduct1.Quantity;
            cartProduct2.TotalProduct = cartProduct2.Price * cartProduct2.Quantity;
            cartProduct3.TotalProduct = cartProduct3.Price * cartProduct3.Quantity;


            // CartProductViewModel'leri tutmak için  listemiz
            var cartProducts = new List<CartProductViewModel> { cartProduct1, cartProduct2, cartProduct3 };

            // Toplam Tutar, KDV Ve Kdv'li Toplam Tutarı hesapladığım bölüm
            var totalPrice = cartProducts.Sum(cp => cp.Price * cp.Quantity);
            var tax = totalPrice * 0.18m; //  KDV oranı %18 olarak belirledim
            var totalPriceWithTax = totalPrice + tax;


            // View'e dönülecek bir view modelimiz
            var viewModel = new CartProductViewModel
            {
                CartProducts = cartProducts,
                TotalPrice = totalPrice,
                Tax = tax,
                TotalPriceWithTax = totalPriceWithTax
            };

            return View(viewModel);
        }
    }
}

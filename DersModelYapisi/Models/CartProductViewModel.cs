namespace DersModelYapisi.Models
{
    public class CartProductViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public List<CartProductViewModel> CartProducts { get; set; }
        public decimal TotalPrice { get; set; } 
        public decimal Tax { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public decimal TotalProduct { get; set; }
    }
}

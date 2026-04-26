using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly decimal _shippingFee;

        public CartController(ApplicationDbContext context, IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._shippingFee = configuration.GetValue<decimal>("CartSettings:ShippingFee");
        }
        public IActionResult Index()
        {
            List<OrderItem> cartItems = CartHelper.GetCartItems(Request, Response, _context);
            decimal subtotal = CartHelper.GetSubtotal(cartItems);

            ViewBag.CartItems = cartItems;
            ViewBag.ShippingFee = _shippingFee;
            ViewBag.Subtotal = subtotal;
            ViewBag.Total = subtotal + _shippingFee;

            return View();
        }
    }
}

using BestStoreMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestStoreMVC.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("/Admin/Orders/{action=Index}/{id?}")]
    public class AdminOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminOrdersController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.Client)
                .Include(o => o.Items).OrderByDescending(o => o.Id).ToList();

            ViewBag.Orders = orders;
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependens_Migration.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Dependens_Migration.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
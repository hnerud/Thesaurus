using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thesaurus.Data;

namespace Thesaurus.Controllers
{
    public class AppController : Controller
    {
        private ApplicationDbContext _context;

        public AppController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var data = _context.Vocabulary.ToList();
            return View(data);
        }
    }
}
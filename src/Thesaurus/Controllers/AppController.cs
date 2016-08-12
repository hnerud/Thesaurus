using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thesaurus.Data;
using Thesaurus.Models;
using Microsoft.AspNetCore.Authorization;

namespace Thesaurus.Controllers
{
    public class AppController : Controller
    {
       
        private IRepository _repository;

        public AppController(IRepository repository)
        {
            _repository = repository;

        }
        
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
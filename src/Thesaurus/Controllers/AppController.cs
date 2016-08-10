using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thesaurus.Data;
using Thesaurus.Models;

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
            var data = _repository.GetVocab();
            return View(data);
        }
    }
}
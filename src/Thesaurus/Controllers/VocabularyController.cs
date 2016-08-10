using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thesaurus.Models;
using AutoMapper;
using System.Collections;
using Microsoft.Extensions.Logging;
using NuGet.Common;

namespace Thesaurus.Controllers
{
    //[Produces("application/json")]

    [Route("Vocabulary")]
    public class VocabularyController : Controller
    {
        private ILogger<VocabularyController> _logger;
        private IRepository _repository;

         public VocabularyController(IRepository repository, ILogger<VocabularyController> logger)
        {
            _repository = repository;
            _logger= logger;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetVocab();
                return Ok(Mapper.Map<IEnumerable<VocabViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get vocabulary: {ex}");
                return BadRequest("Error Occurred");
            }
        }

    // POST: api/Vocabulary
    [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]VocabViewModel value)
        {
            if (ModelState.IsValid)
            {
                var newTerm = Mapper.Map<Vocabulary>(value);
                _repository.AddVocab(newTerm);

                if (await _repository.SaveChangesAsync())
                {

                    return Created($"Vocabulary/{value.term})", Mapper.Map<VocabViewModel>(newTerm));
                }
               
            }
            return BadRequest("Failed to save the trip");
           
        }


        //// GET: api/Vocabulary
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Vocabulary/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// PUT: api/Vocabulary/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

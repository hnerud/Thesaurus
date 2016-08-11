using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thesaurus.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Collections;

namespace Thesaurus.Controllers
{
    [Route("vocabulary/{vocab}/contextTerms")]
    public class ContextTermController : Controller
    {
        private ILogger<ContextTermController> _logger;
        private IRepository _repository;

        public ContextTermController(IRepository repository, ILogger<ContextTermController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Get(string Vocab)
        {
            try
            {
                var vocabulary = _repository.GetAssociatedVocab(Vocab);

                return Ok(Mapper.Map<IEnumerable<ContextTermViewModel>>(vocabulary.contextTerms.ToList()));
            }

            catch (Exception ex)
            {
                _logger.LogError("Failed to get context term: {0}", ex);
            }
            return BadRequest("Failed to get Context Terms");
        }
        [HttpPost("")]
        public async Task <IActionResult> Post(string Vocab,[FromBody]ContextTermViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newContextTerm = Mapper.Map<ContextTerm>(vm);

                    _repository.AddContextTerm(Vocab, newContextTerm);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"Vocabulary/{Vocab}/contextTerms/{newContextTerm.term}",
                            Mapper.Map<ContextTermViewModel>(newContextTerm));
                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new context term: {0}", ex);

            }
            return BadRequest("Failed to save context term");
            

        }
    }
}
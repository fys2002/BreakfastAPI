using BreakfastAPI.Models;
using BreakfastAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BreakfastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly BreakfastService _breakfastService;

        public BreakfastController()
        {
            _breakfastService = new BreakfastService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Breakfast>> GetAll()
        {
            return Ok(_breakfastService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Breakfast> GetById(int id)
        {
            var breakfast = _breakfastService.GetById(id);
            if (breakfast == null)
            {
                return NotFound();
            }
            return Ok(breakfast);
        }

        [HttpPost]
        public ActionResult<Breakfast> Add(Breakfast breakfast)
        {
            _breakfastService.Add(breakfast);
            return CreatedAtAction(nameof(GetById), new { id = breakfast.Id }, breakfast);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Breakfast breakfast)
        {
            if (id != breakfast.Id)
            {
                return BadRequest();
            }

            var existingBreakfast = _breakfastService.GetById(id);
            if (existingBreakfast == null)
            {
                return NotFound();
            }

            _breakfastService.Update(breakfast);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var breakfast = _breakfastService.GetById(id);
            if (breakfast == null)
            {
                return NotFound();
            }

            _breakfastService.Delete(id);
            return NoContent();
        }
    }
}
using FeedbackSystem.Models;
using FeedbackSystem.Repositories;
using global::FeedbackSystem.Models;
using global::FeedbackSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// Student ID: 00016119

namespace FeedbackSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var items = await _unitOfWork.Categories.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var item = await _unitOfWork.Categories.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category item)
        {
            await _unitOfWork.Categories.AddAsync(item);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.CategoryId }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category item)
        {
            if (id != item.CategoryId) return BadRequest();

            _unitOfWork.Categories.Update(item);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Categories.GetByIdAsync(id);
            if (item == null) return NotFound();

            _unitOfWork.Categories.Delete(item);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
    }
}


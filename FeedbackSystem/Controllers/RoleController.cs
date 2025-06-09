using FeedbackSystem.Models;
using FeedbackSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

// Student ID: 00016119

namespace FeedbackSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var items = await _unitOfWork.Roles.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var item = await _unitOfWork.Roles.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(Role item)
        {
            await _unitOfWork.Roles.AddAsync(item);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.RoleId }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Role item)
        {
            if (id != item.RoleId) return BadRequest();

            _unitOfWork.Roles.Update(item);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Roles.GetByIdAsync(id);
            if (item == null) return NotFound();

            _unitOfWork.Roles.Delete(item);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
    }
}

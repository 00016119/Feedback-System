using FeedbackSystem.Data;
using FeedbackSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAll()
        {
            var list = await _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Category)
                .ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetById(int id)
        {
            var item = await _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.FeedbackId == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = feedback.FeedbackId }, feedback);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Feedback feedback)
        {
            if (id != feedback.FeedbackId)
                return BadRequest();

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _context.Feedbacks.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Feedbacks.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

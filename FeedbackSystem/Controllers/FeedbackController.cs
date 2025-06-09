using FeedbackSystem.Data;
using FeedbackSystem.Models;
using FeedbackSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ID: 00016119

namespace FeedbackSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFeedbackRepository _feedbackRepo;


        public FeedbackController(IUnitOfWork unitOfWork, IFeedbackRepository feedbackRepo)
        {
            _unitOfWork = unitOfWork;
            _feedbackRepo = feedbackRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAll()
        {
            var items = await _feedbackRepo.GetAllWithUserAndCategoryAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetById(int id)
        {
            var item = await _feedbackRepo.GetByIdWithUserAndCategoryAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> Create([FromBody] Feedback feedback)
        {
            await _unitOfWork.Feedbacks.AddAsync(feedback);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(GetById), new { id = feedback.FeedbackId }, feedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Feedback feedback)
        {
            if (id != feedback.FeedbackId)
                return BadRequest();

            _unitOfWork.Feedbacks.Update(feedback);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(id);
            if (feedback == null)
                return NotFound();

            _unitOfWork.Feedbacks.Delete(feedback);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
    }

}

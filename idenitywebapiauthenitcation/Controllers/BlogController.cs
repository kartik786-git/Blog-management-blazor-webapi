using idenitywebapiauthenitcation.Entity;
using idenitywebapiauthenitcation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace idenitywebapiauthenitcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _blogService.GetAllAsync();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reponse = await _blogService.GetByIdAsync(id);
            return Ok(reponse);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post(Blog blog)
        {
            var respone = await _blogService.CreateAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = respone.Id }, respone);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog updatedBlog)
        {
            var existingBlog = await _blogService.UpdateAsync(id, updatedBlog);
            if (!existingBlog)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.DeleteAsync(id);
            if (!blog)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}

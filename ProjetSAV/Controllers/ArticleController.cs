using Application.Interfaces.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetSAV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IService<Article> _serviceArticle;

        public ArticleController(IService<Article> serviceArticle)
        {
            _serviceArticle = serviceArticle;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var articles = await _serviceArticle.GetAllAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _serviceArticle.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Article is null.");
            }

            var createdArticle = await _serviceArticle.AddAsync(article);
            return CreatedAtAction(nameof(GetById), new { id = createdArticle.Id }, createdArticle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Article article)
        {
            if (article == null || article.Id != id)
            {
                return BadRequest("Article is null or ID mismatch.");
            }

            var existingArticle = await _serviceArticle.GetByIdAsync(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            await _serviceArticle.UpdateAsync(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _serviceArticle.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            await _serviceArticle.DeleteAsync(id);
            return NoContent();
        }
    }
}
using Application.Interfaces.IServices;
using Application.Interfaces.Repository;
using Domain.Entities;


namespace Application.Services
{

    public class ServiceArticle : IService<Article>
    {
        private readonly IGenericRepository<Article> _articleRepository;

        public ServiceArticle(IGenericRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _articleRepository.GetAllAsync();
        }


        public async Task<Article> GetByIdAsync(int id)
        {
            return await _articleRepository.GetByIdAsync(id);
        }

        public async Task<Article> AddAsync(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article), "Article is null.");
            }

            var articleEntity = new Article
            {
                Title = article.Title,
                Description = article.Description,
                DateAchat = article.DateAchat,
                Prix = article.Prix,
                GarantieEnMois = article.GarantieEnMois
            };

            return await _articleRepository.AddAsync(articleEntity);
        }

        public async Task UpdateAsync(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article), "Article is null.");
            }

            var existingArticle = await _articleRepository.GetByIdAsync(article.Id);
            if (existingArticle == null)
            {
                throw new KeyNotFoundException("Article not found.");
            }

            existingArticle.Title = article.Title;
            existingArticle.Description = article.Description;
            existingArticle.DateAchat = article.DateAchat;
            existingArticle.Prix = article.Prix;
            existingArticle.GarantieEnMois = article.GarantieEnMois;

            await _articleRepository.UpdateAsync(existingArticle);
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            if (article == null)
            {
                throw new KeyNotFoundException("Article not found.");
            }

            await _articleRepository.DeleteAsync(article);
        }
    }
}
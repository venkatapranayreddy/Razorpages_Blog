using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razorpages.Data;
using Razorpages.Models;

namespace Razorpages.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _blogDbContext;

        public BlogRepository(BlogDBContext blogDbContext)
        {
           _blogDbContext = blogDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _blogDbContext.BlogPost.AddAsync(blogPost);
            await _blogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await _blogDbContext.BlogPost.FindAsync(id);

            if (existingBlog != null)
            {
                _blogDbContext.BlogPost.Remove(existingBlog);
                await _blogDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _blogDbContext.BlogPost.ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName)
        {
            return await _blogDbContext.BlogPost.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await _blogDbContext.BlogPost.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> GetAsync(string urlHandle)
        {
            return await _blogDbContext.BlogPost.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await _blogDbContext.BlogPost.FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;

            
            }

            await _blogDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
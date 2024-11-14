using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razorpages.Models;

namespace Razorpages.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<IEnumerable<BlogPost>> GetAllAsync(string tagName);
        Task<BlogPost> GetAsync(Guid id);
        Task<BlogPost> GetAsync(string urlHandle);
        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<bool> DeleteAsync(Guid id);
    }
}
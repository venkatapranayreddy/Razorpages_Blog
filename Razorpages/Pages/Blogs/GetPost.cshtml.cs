using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Razorpages.Data;
using Razorpages.Models;

namespace Razorpages.Pages.Blogs
{
    public class GetPost : PageModel
    {
        public List<BlogPost> BlogPosts { get; set; }
        private readonly BlogDBContext  _blogDBContext;

        private readonly ILogger<GetPost> _logger;

        public GetPost(BlogDBContext  blogDBContext, ILogger<GetPost> logger)
        {
            _logger = logger;
            _blogDBContext =   blogDBContext;
            
        }

        public  async Task OnGet()
        {
            BlogPosts =   await _blogDBContext.BlogPost.ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razorpages.Data;
using Razorpages.Models;
using Razorpages.ViewModels;

namespace Razorpages.Pages.Blogs
{
    public class AddPost : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        private readonly BlogDBContext _blogDBContext;
        private readonly ILogger<AddPost> _logger;


        public AddPost(BlogDBContext blogDBContext, ILogger<AddPost> logger)
        {
            _logger = logger;
            _blogDBContext = blogDBContext;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };

            _blogDBContext.BlogPost.Add(blogPost);
            _blogDBContext.SaveChanges();

            

        }
    }
}
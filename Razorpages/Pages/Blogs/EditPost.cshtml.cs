using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razorpages.Data;
using Razorpages.Models;
using Razorpages.Repositories;

namespace Razorpages.Pages.Blogs
{
    public class EditPost : PageModel
    {
        [BindProperty]
       public  BlogPost BlogPost {get; set;}

        private readonly IBlogRepository _iBlogRepository;
        private readonly ILogger<EditPost> _logger;

        public EditPost(IBlogRepository iBlogRepository, ILogger<EditPost> logger)
        {
            _logger = logger;
            _iBlogRepository = iBlogRepository;
        }

        public async Task OnGet(Guid id)
        {
              BlogPost =   await _iBlogRepository.GetAsync(id);

        }

        public async Task<IActionResult>  OnPostEdit()
        {
            var ExistingPost = await  _iBlogRepository.GetAsync(BlogPost.Id);

            if(ExistingPost!= null)
            {
                ExistingPost.Heading = BlogPost.Heading;
                ExistingPost.PageTitle = BlogPost.PageTitle;
                ExistingPost.Content = BlogPost.Content;
                ExistingPost.ShortDescription = BlogPost.ShortDescription;
                ExistingPost.PublishedDate = BlogPost.PublishedDate;
                ExistingPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                ExistingPost.UrlHandle = BlogPost.UrlHandle;
                ExistingPost.Author = BlogPost.Author;
                ExistingPost.Visible = BlogPost.Visible;

            }
            await _iBlogRepository.UpdateAsync(ExistingPost);

            return RedirectToPage("/Blogs/GetPost");
        }
    


         public async Task<IActionResult> OnPostDelete()
        {    
           var ExistingPost =  await _iBlogRepository.DeleteAsync(BlogPost.Id);

            return RedirectToPage("/Blogs/GetPost");
        }
    }



}
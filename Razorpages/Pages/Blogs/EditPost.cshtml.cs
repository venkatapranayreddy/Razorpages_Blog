using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razorpages.Data;
using Razorpages.Models;

namespace Razorpages.Pages.Blogs
{
    public class EditPost : PageModel
    {
        [BindProperty]
       public  BlogPost BlogPost {get; set;}

        private readonly BlogDBContext _blogDBContext;
        private readonly ILogger<EditPost> _logger;

        public EditPost(BlogDBContext blogDBContext, ILogger<EditPost> logger)
        {
            _logger = logger;
            _blogDBContext= blogDBContext;
        }

        public async Task OnGet(Guid id)
        {
              BlogPost =   await _blogDBContext.BlogPost.FindAsync(id);

        }

        public async Task<IActionResult>  OnPostEdit()
        {
            var ExistingPost = await  _blogDBContext.BlogPost.FindAsync(BlogPost.Id);

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
            _blogDBContext.SaveChanges();

            return RedirectToPage("/Blogs/GetPost");
        }
    


         public async Task<IActionResult> OnPostDelete()
        {    
           var ExistingPost =  _blogDBContext.BlogPost.Find(BlogPost.Id);
             if(ExistingPost!= null)
             {
                _blogDBContext.BlogPost.Remove(ExistingPost);
                await _blogDBContext.SaveChangesAsync();

                
             }

            return RedirectToPage("/Blogs/GetPost");
        }
    }



}
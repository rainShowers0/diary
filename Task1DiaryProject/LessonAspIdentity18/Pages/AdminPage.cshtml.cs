using System;
using System.Collections.Generic;
using LessonAspIdentity18.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LessonAspIdentity18.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly UContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminPageModel(UContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Post userpost { get; set; }
        public List<Post> posts { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                posts = await _context.Posts.Where(p => p.UserID == user.Id).ToListAsync();
            }
        }

        public string statusmsg = "";

        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPostSavePost()
        {
            if (ModelState.IsValid)
            {
                int ok = 0;
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var imagePath = Path.Combine("wwwroot/img", Image.FileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                        }

                        userpost.UserID = user.Id;
                        userpost.ImgPath = imagePath;
                        userpost.CDate = DateTime.Now;
                        userpost.MDate = DateTime.Now;

                        await _context.Posts.AddAsync(userpost);
                        ok = await _context.SaveChangesAsync();
                        posts = await _context.Posts.Where(p => p.UserID == userpost.UserID).ToListAsync();
                    }
                }
                if (ok == 1)
                {
                    statusmsg = "success";
                }
                else
                {
                    statusmsg = "error";
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeletePost()
        {
            if (ModelState.IsValid)
            {
                var u = await _userManager.FindByNameAsync(User.Identity.Name);
                if (u != null)
                {
                    var postToDelete = await _context.Posts.FindAsync(userpost.Id);
                    if (postToDelete != null)
                    {
                        _context.Posts.Remove(postToDelete);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return Page();
        }
    }
}

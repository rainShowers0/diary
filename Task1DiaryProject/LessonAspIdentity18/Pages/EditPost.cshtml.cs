using LessonAspIdentity18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LessonAspIdentity18.Pages
{
    public class EditPostModel : PageModel
    {
        private readonly UContext _context;
        public EditPostModel(UContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Post post { get; set; }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Request.Query["PostID"]))
            {
                int postid = int.Parse(Request.Query["PostID"].ToString());
                var urdun = _context.Posts.Where(po => po.Id == postid).FirstOrDefault();
                if(urdun != null)
                {
                    post = urdun;
                }
            }
        }
        public string errmsg = "";
        public async Task<IActionResult> OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                if (post != null)
                {
                    var p = _context.Posts.Where(po => po.PostTitle == post.PostTitle).FirstOrDefault();
                    if (p != null)
                    {
                        if (p.Id != post.Id)
                        {
                            errmsg = "duplicated";
                        }
                        else
                        {
                            p.PostTitle = post.PostTitle;
                            p.PostBody= post.PostBody;
                            p.MDate = DateTime.Now;
                            int urdun = 0;
                            urdun = await _context.SaveChangesAsync();
                            if(urdun == 1)
                            {
                                return RedirectToPage("/AdminPage");
                            }
                            else
                            {
                                errmsg = "error";
                            }
                        }
                    }
                }
                
            }

            return Page();
        }
    }
}

using LessonAspIdentity18.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LessonAspIdentity18.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signinmanager;
        private readonly UContext _context;
        public LoginModel(SignInManager<IdentityUser> signinmanager,UContext uContext)
        {
            _signinmanager = signinmanager; 
            _context = uContext;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        [Required(ErrorMessage = "хэрэглэгчийн нэр оруулна уу")]
        [StringLength(50, ErrorMessage = "хэрэглэгчийн нэр 50 тэмдэгтээс уртгүй байна")]
        public string UserName { get; set; } = "";
        [BindProperty]
        [Required(ErrorMessage = "нууц үг оруулна уу")]
        [StringLength(20, ErrorMessage = "нууц үг 20 тэмдэгтээс уртгүй байна")]
        public string Password { get; set; } = "";
        [BindProperty]
        public bool RememberMe { get; set; }

        public string result = "";
        public string errmsg = "";
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
        
                var urdun=await _signinmanager.PasswordSignInAsync(UserName,Password,RememberMe,lockoutOnFailure:true);
                if(urdun.Succeeded)
                {
                    return RedirectToPage("/AdminPage");
                }
                else
                {
                    result = "failed";
                    var myuser = _context.Users.Where(u => u.UserName == UserName).FirstOrDefault();
                    if(myuser!= null) 
                    {
                        int faildsentoo = myuser.AccessFailedCount;
                        errmsg="танд одоо "+(5-faildsentoo)+" оролдлого үлдлээ";
                    }
                }
                if(urdun.IsLockedOut) 
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }

}

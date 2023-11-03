using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonAspIdentity18.Pages
{
    public class AddUserModel : PageModel
    {
        public void OnGet()
        {
        }
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AddUserModel(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [BindProperty]
        [Required(ErrorMessage ="хэрэглэгчийн нэр оруулна уу")]
        [StringLength(50,ErrorMessage ="хэрэглэгчийн нэр 50 тэмдэгтээс уртгүй байна")]
        public string UserName { get; set; } = "";
        [BindProperty]
        [Required(ErrorMessage ="нууц үг оруулна уу")]
        [StringLength(20,ErrorMessage ="нууц үг 20 тэмдэгтээс уртгүй байна")]
        public string Password { get; set; } = "";
        [BindProperty]
        [Required(ErrorMessage ="нууц үгийн давталтыг оруулна уу")]
        [Compare("Password",ErrorMessage ="нууц үгийн давталт буруу байна")]
        public string ConfirmPassword { get; set; } ="";

        public string result = "";
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                //1.hereglegchii ugugduliig hadgalah object uusgene
                IdentityUser shineuser = new IdentityUser();
                //2. ug object-g hereglegchiin uguguduliig hadgalna
                shineuser.UserName = UserName;
               //  shineuser.PasswordHash = Password;
                //3. UserManager class-n CreateAsync() -eer shine hereglegchiig uusgene. end aldaa bsan bna.
                //ANHAAR: password iig PassworHash ruu hadgalahgui damjuulah baijee
                var urdun=await _userManager.CreateAsync(shineuser,Password);
                if (urdun.Succeeded)//herev hereglegch amjilttai uusvel
                {
                    result = "success";
                }
                else
                {
                    result ="error";
                }
            }
            return Page();
        }
    }
}

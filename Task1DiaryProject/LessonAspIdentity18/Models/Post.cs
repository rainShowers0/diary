using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LessonAspIdentity18.Models
{
    [Table("UserPosts")]
    public class Post
    {
        [Key]   
        public int Id { get; set; }
        public string UserID { get; set; } = "";
        [Required(ErrorMessage ="гарчиг оруулна уу")]
        [StringLength(100,ErrorMessage ="100 Тэмдэгтээс уртгүй байн")]
        public string PostTitle { get; set; } = "";
        [Required(ErrorMessage ="тэмдэглэл оруулна уу")]
        [StringLength(2000,ErrorMessage ="2000 тэмдэгтээс уртгүй байна")]
        public string PostBody { get; set; } = "";
        public string ImgName { get; set; } = "";
        public string ImgPath { get; set; } = "";
        public string Video { get; set; } = "";

        public DateTime CDate { get; set; }
        public DateTime MDate { get; set; }
    }
}

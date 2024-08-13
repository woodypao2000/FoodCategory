using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace MVC8.Models
{
    public class Category
    {
        [Key] //定義table
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [DisplayName("類別名稱")]
        public string Name { get; set; }
        [DisplayName("顯示順序")]
        [Range(1, 100, ErrorMessage = "最多100")]
        public int DisplayOrder { get; set; }
    }
}

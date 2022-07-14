using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementApp.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage ="Please Enter Book Name")]  
        public string BookName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(AllowEmptyStrings = true)]
        public string Author { get; set; }
        public int Price { get; set; }


    }
}

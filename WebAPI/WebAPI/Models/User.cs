using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide Email")]
        public string Email { get; set; }

    }
}

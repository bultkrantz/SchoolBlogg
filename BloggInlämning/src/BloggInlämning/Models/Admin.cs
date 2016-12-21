using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BloggInlämning.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Användarnamn:")]
        [Required(ErrorMessage = "Ange ett användarnamn")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ange ett lösenord")]
        [Display(Name = "Lösenord:")]
        public string Password { get; set; }
    }
}

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


        [Display(Name = "Lösenord:")]
        [Required(ErrorMessage = "Ange ett lösenord")]
        public string Password { get; set; }
    }
}

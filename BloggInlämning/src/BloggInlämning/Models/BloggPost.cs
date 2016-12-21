using System;
using System.ComponentModel.DataAnnotations;

namespace BloggInlämning.Models
{
    public class BloggPost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange en rubrik")]
        [StringLength(2000, ErrorMessage = "Bloggrubriker får inte vara längre än 50 tecken")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Du måste skriva något i ditt inlägg")]
        [StringLength(2000, ErrorMessage = "Bloggtext får inte vara längre än 2000 tecken eller kortare än 10 tecken", MinimumLength = 20)]
        public string Text { get; set; }

        public DateTime BloggDate { get; set; }

        [Required(ErrorMessage = "Du måste välja en kategori")]
        [Range(typeof(int), "1", "10", ErrorMessage = "Du måste välja en kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggInlämning.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<BloggPost> BloggPosts { get; set; }
    }
}

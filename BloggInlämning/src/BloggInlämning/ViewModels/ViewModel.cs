using System.Collections.Generic;
using BloggInlämning.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloggInlämning.ViewModels
{
    public class ViewModel
    {
        public List<BloggPost> BloggPosts { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}

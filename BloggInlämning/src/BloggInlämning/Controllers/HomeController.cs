using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BloggInlämning.Models;
using BloggInlämning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloggInlämning.Controllers
{
    public class HomeController : Controller
    {
        private readonly BloggContext _bloggContext;
        private readonly ViewModel _viewModel;
        private readonly List<SelectListItem> _selectList = new List<SelectListItem>();

        public HomeController(BloggContext bloggContext)
        {
            _bloggContext = bloggContext;



            var categoryList = _bloggContext.Categories.ToList();
            foreach (var c in categoryList)
            {
                _selectList.Add(new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            }

            _viewModel = new ViewModel()
            {
                BloggPosts = _bloggContext.BloggPosts.OrderByDescending(x => x.BloggDate).ToList(),
                Categories = _selectList
            };
        }



        public IActionResult Index()
        {
            ViewBag.categories = _selectList;
            return View(_viewModel);
        }

        public IActionResult NewPost()
        {
            ViewBag.categories = _selectList;
            return View();
        }

        [HttpPost]
        public IActionResult NewPost(BloggPost bloggPost)
        {
            ViewBag.categories = _selectList;

            if (ModelState.IsValid)
            {
                bloggPost.BloggDate = DateTime.Now;
                _bloggContext.BloggPosts.Add(bloggPost);
                _bloggContext.SaveChanges();
                ModelState.Clear();
                TempData["success"] = "Inlägg Skapat";
                return View();
            }
            return View();
        }

        public IActionResult PostByCategory(int category)
        {
            ViewBag.categories = _selectList;

            var viewModel = new ViewModel()
            {
                BloggPosts =
                    _bloggContext.BloggPosts.OrderByDescending(x => x.BloggDate)
                        .Where(x => x.CategoryId == category)
                        .ToList(),
                Categories = _selectList
            };
            return View("Index", viewModel);
        }

        public IActionResult Search(string search)
        {
            ViewBag.categories = _selectList;
            var viewModel = new ViewModel()
            {
                BloggPosts = _bloggContext.BloggPosts.OrderByDescending(x => x.BloggDate)
                    .Where(x => x.Heading.ToUpper().Contains(search.ToUpper()) ||
                                x.Category.Name.ToUpper().Contains(search.ToUpper()) ||
                                x.Text.ToUpper().Contains(search.ToUpper()))
                    .ToList(),
                Categories = _selectList
            };

            return View("Index", viewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.categories = _selectList;

            var bloggPost = _bloggContext.BloggPosts.FirstOrDefault(x => x.Id == id);
            return View(bloggPost);
        }

        [HttpPost]
        public IActionResult Edit(BloggPost bloggPost)
        {
            ViewBag.categories = _selectList;

            if (ModelState.IsValid)
            {
                var editedPost = _bloggContext.BloggPosts.FirstOrDefault(x => x.Id == bloggPost.Id);

                editedPost.Id = bloggPost.Id;
                editedPost.BloggDate = bloggPost.BloggDate;
                editedPost.CategoryId = bloggPost.CategoryId;
                editedPost.Heading = bloggPost.Heading;
                editedPost.Text = bloggPost.Text;

                _bloggContext.Update(editedPost);
                _bloggContext.SaveChangesAsync();

                TempData["success"] = "Inlägg Redigerat";
                return View(bloggPost);
            }
            return View(bloggPost);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.categories = _selectList;
            var bloggPost = _bloggContext.BloggPosts.FirstOrDefault(x => x.Id == id);

            _bloggContext.Remove(bloggPost);
            _bloggContext.SaveChanges();

            return View("Edit");
        }

        public IActionResult Welcome(Admin admin)
        {
            return View(admin);
        }
    }
}

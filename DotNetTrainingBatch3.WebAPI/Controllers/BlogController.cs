using DotNetTrainingBatch3.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetTrainingBatch3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.Id).ToList();
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Succesfully." : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.Id == id);

            if (item is null)
            {
                return NotFound("No data found.");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Updated Successfully" : "Updated Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.Id == id);

            if (item is null) return NotFound("No data found.");

            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();

            string message = result > 0 ? "Delete successfully." : "Fail to delete.";
            return Ok(message);
        }
    }
}

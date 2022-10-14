using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext context;

        public CommentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Comment> comments = context.Comments.ToList();
            return View(comments);
        }
        public IActionResult Delete(int? id)
        {
            Comment comment = context.Comments.FirstOrDefault(c => c.Id == id);
            context.Comments.Remove(comment);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

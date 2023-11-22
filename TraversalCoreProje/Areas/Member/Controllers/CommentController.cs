using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var user = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = _commentService.TGetListCommentWithDestinationByID(user);
            ViewBag.count = values.Count();
            return View(values);
        }
    }
}

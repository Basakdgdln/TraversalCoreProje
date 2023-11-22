using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {

            ViewBag.comment_count = cm.TGetList().Where(x => x.DestinationID == id).Count();
            return View(cm.TGetListCommentWithDestinationAndUser(id));
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }
        public List<Comment> TGetDestinationByID(int id)
        {
            return _commentDal.GetListByFİlter(x => x.DestinationID == id).ToList();
        }
        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }

        public List<Comment> TGetListByID(int id)
        {
            return _commentDal.GetListByFİlter(x => x.AppUserID == id);
        }

        public List<Comment> TGetListCommentWithDestinationByID(int id)
        {
            return _commentDal.GetListCommentWithDestinationByID(id);
        }
    }
}

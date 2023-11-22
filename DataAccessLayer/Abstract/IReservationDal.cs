using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithApprovalReservation(int id);
        List<Reservation> GetListWithAcceptedReservation(int id);
        List<Reservation> GetListWithPreviousReservation(int id);
        Reservation GetListWithReservationByID(int id);
        List<Reservation> GetList(int id);
        List<Reservation> AllGetList();
    }
}

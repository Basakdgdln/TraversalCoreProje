using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetListApprovalReservation(int id);
        List<Reservation> GetListAcceptedReservation(int id);
        List<Reservation> GetListPreviousReservation(int id);
        public Reservation TGetListWithReservationByID(int id);
        List<Reservation> TGetList(int id);
        List<Reservation> TAllGetList();
    }
}

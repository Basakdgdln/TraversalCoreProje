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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetListAcceptedReservation(int id)
        {
            return _reservationDal.GetListWithAcceptedReservation(id);
        }

        public List<Reservation> GetListApprovalReservation(int id)
        {
            return _reservationDal.GetListWithApprovalReservation(id);
        }

        public List<Reservation> GetListPreviousReservation(int id)
        {
            return _reservationDal.GetListWithPreviousReservation(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public void TUpdate(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation TGetListWithReservationByID(int id)
        {
            return _reservationDal.GetListWithReservationByID(id);
        }

        public List<Reservation> TGetList(int id)
        {
            return _reservationDal.GetList(id);
        }

        public List<Reservation> TAllGetList()
        {
            return _reservationDal.AllGetList();
        }
    }
}

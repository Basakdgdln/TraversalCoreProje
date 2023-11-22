using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> AllGetList()
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Include(x => x.Guide).ToList();
            }
        }

        public List<Reservation> GetList(int id)
        {
             using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Include(x => x.Guide).Where(x => x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithAcceptedReservation(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Include(x => x.Guide).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithApprovalReservation(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Include(x => x.Guide).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithPreviousReservation(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public Reservation GetListWithReservationByID(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Where(x => x.DestinationID == id).FirstOrDefault();
            }
        }
    }
}

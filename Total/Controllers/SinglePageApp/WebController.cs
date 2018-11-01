using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Total.Models.SinglePageApp;

namespace Total.Controllers.SinglePageApp
{
    public class WebController : ApiController
    {
        ReservationRepository repository=ReservationRepository.Current;

        public IEnumerable<Reservation> GetAllReservations()
        {
            return repository.GetAll;
        }

        public Reservation GetReservation(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public Reservation PostReservation(Reservation item)
        {
            return repository.Add(item);
        }

        [HttpPut]
        public bool PutReservation(Reservation item)
        {
            return repository.Update(item);
        }

        public void DeleteReservation(int id)
        {
            repository.Remove(id);
        }
    }
}
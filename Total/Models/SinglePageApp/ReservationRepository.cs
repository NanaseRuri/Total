using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.SinglePageApp
{
    public class ReservationRepository
    {
        private static ReservationRepository repo=new ReservationRepository();

        public static ReservationRepository Current => repo;

        private List<Reservation> reservationList=new List<Reservation>()
        {
            new Reservation {
                Id = 1, Name = "Adam", Location = "Board Room"},
            new Reservation {
                Id = 2, Name = "Jacqui", Location = "Lecture Hall"},
            new Reservation {
                Id = 3, Name = "Russell", Location = "Meeting Room 1"},
        };

        public Reservation Add(Reservation item)
        {
            item.Id = reservationList.Count + 1;
            reservationList.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation target= reservationList.FirstOrDefault(r => r.Id == id);
            if (target!=null)
            {
                reservationList.Remove(target);
            }            
        }

        public Reservation Get(int id)
        {
            return reservationList.FirstOrDefault(r => r.Id == id);
        }

        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.Id);
            if (storedItem!=null)
            {
                storedItem.Name = item.Name;
                storedItem.Location = item.Location;
                return true;
            }

            return false;
        }

        public IEnumerable<Reservation> GetAll => reservationList;
    }
}
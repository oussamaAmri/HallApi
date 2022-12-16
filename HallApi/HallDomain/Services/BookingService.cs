using HallDomain.Interfaces;
using HallDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HallDomain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        //constructeur
        public BookingService(IBookingRepository bookingRepository)
        {
            _repository = bookingRepository;
        }
        
        public async Task<ResultCreationBooking> AddReservationAsync(Booking reservation)
        {
//            var reservation = new Booking();
            //Vérification des créneaux 0=>23
            if (reservation.StartSlot < 0 && reservation.EndSlot > 23)
            {
                var ResultCreatBooking = new ResultCreationBooking();
                ResultCreatBooking.ErrorMSG = "Réservation non confirmer";
                return ResultCreatBooking;
                //reservation non confirmer
                //creation obj model 
            }
//            var myList = new List<Booking>();
            var verificationReservation = await _repository.GetReservationsAsync();
            bool nonDisponible = false;
            foreach(var check in verificationReservation)
            {
                if(reservation.BookingDate==check.BookingDate)
                {
                    if (check.RoomId == reservation.RoomId)
                    {
                        //test creneux 
//                        if ((reservation.StartSlot == check.StartSlot && reservation.EndSlot == check.EndSlot) ||(reservation.StartSlot > 0 || reservation.EndSlot<23)) 
                            if(check.StartSlot >= reservation.StartSlot && check.StartSlot <= reservation.EndSlot || 
                                check.EndSlot >= reservation.StartSlot && check.EndSlot <= reservation.EndSlot)

                        {
                            nonDisponible = true;
                        }
                    }
                }
            }
            if (nonDisponible)
            {
                //retourner les créneaux disponible 
                var ResultCreatBooking = new ResultCreationBooking();
                var list = new List<Booking>();
                var ListeDisponible = new List<Slot>();
                int i, j;
                int startSlot = 0;
                int endSlot = 1;
                /*                foreach (var check in verificationReservation)
                                {
                                    if
                //                    list.Add(check); 
                                }*/
                for (i=0; i <= 23; i++)
                {
                    for(j=1 ;j<=23; j++)
                    {
                        foreach (var check in verificationReservation)
                        {
                            if(check.StartSlot!= i && check.EndSlot != j)
                            {
                                var slot = new Slot(i,j);
                                startSlot = i;
                                endSlot = j;
                                ListeDisponible.Add(slot);
                            }
                        }
                    }                    
                }
                ResultCreatBooking.ListReservation = ListeDisponible;
                return ResultCreatBooking; 
            }
            
            
            var booking = await _repository.AddReservationAsync(reservation);
                        
            var resultcreatebooking = new ResultCreationBooking();
            resultcreatebooking.booking = booking;
            return resultcreatebooking;
            //Vérifier la disponibilité d'un créneau 

            /*
             * Propièter pour vérifier si c'est créer ou non 
             * Propièter de récaputilatif de la reservation 
             * la listes des creneaux disponible 
             * Message destiner aux utilisateurs expliquant le sousi 
             */

        }
        public async Task<IEnumerable<Booking>> GetReservationsAsync()
        {
            return await _repository.GetReservationsAsync();
        }

    }
}

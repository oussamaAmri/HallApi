using HallDomain.Interfaces;
using HallDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

//ajout méthode supprimer reservation
//ajout méthode qui prend on paramètre un id de la salle qui renvois toutes les reservations pour la salle
//ajout des test sur la méthode pour reserver une salle 
namespace HallDomain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IHallService _hallService;
        private readonly IPeopleService _peopleService;
        //constructeur
        public BookingService(IBookingRepository bookingRepository, IHallService hallService, IPeopleService peopleService)
        {
            _repository = bookingRepository;
            this._hallService = hallService;
            this._peopleService = peopleService;
        }
        
        private async Task<(string,bool)> CheckRoom(int roomId)
        {
            var hall = await _hallService.GetHallsByIdAsync(roomId);
            if (hall == null)
            {
                var idH = roomId;
                return ("RoomId incorrect N : " + idH,false);
            }
            return (string.Empty, true);
        }

        private async Task<(string,bool)> CheckPeople(int peopleId)
        {
            var people = await _peopleService.GetPeopleByIdAsync(peopleId);
            if (people == null)
            {
                var idP = peopleId;
                return ("PersonId incorrect N : " + idP,false);
            }
            return (string.Empty, true);
        }

        private (string,bool) CheckDate(int startSlot,int EndSlot)
        {

            if (startSlot < 0 && EndSlot > 23)
            {
                return ("Réservation non confirmer" + startSlot + " " + EndSlot ,false);
            }
            return (string.Empty,true);
        }

        private async Task<bool> VerificationReservation(Booking reservation)
        {
            var verificationReservation = await _repository.GetReservationsAsync();
            bool nonDisponible = false;
            foreach (var check in verificationReservation)
            {
                if (reservation.BookingDate.Date == check.BookingDate.Date)
                {
                    if (check.RoomId == reservation.RoomId)
                    {
                        //test creneux 
                        //                        if ((reservation.StartSlot == check.StartSlot && reservation.EndSlot == check.EndSlot) ||(reservation.StartSlot > 0 || reservation.EndSlot<23)) 
                        if (check.StartSlot >= reservation.StartSlot && check.StartSlot <= reservation.EndSlot ||
                            check.EndSlot >= reservation.StartSlot && check.EndSlot <= reservation.EndSlot)

                        {
                            nonDisponible = true;
                        }
                    }
                }
            }
            return nonDisponible;
        }
        public async Task<ResultCreationBooking> AddReservationAsync(Booking reservation)
        {
            //Test sur le roomID 
            (string errorMsgRoom, bool isValidRoom) = await CheckRoom(reservation.RoomId);
            //Test sur PersonID 
            (string errorMsgPeople, bool isValidPeople) = await CheckPeople(reservation.PersonId);
            //Vérification des créneaux 0=>23
            (string errorMsgDate, bool isValidDate) = CheckDate(reservation.StartSlot,reservation.EndSlot);
            if(!isValidRoom||!isValidPeople||!isValidDate)
            {
                var result = new ResultCreationBooking();
                if (!isValidRoom)
                {
                    result.ErrorMSG.Add(errorMsgRoom);
                }
                if(!isValidPeople)
                {
                    result.ErrorMSG.Add(errorMsgPeople);
                }
                if (!isValidDate)
                {
                    result.ErrorMSG.Add(errorMsgDate);
                }
                return result;
            }
            var nonDisponible = await VerificationReservation(reservation);
            if (nonDisponible)
            {
                //retourner les créneaux disponible 
                var currentReservations = await _repository.GetReservationByRommAndByDate(reservation.RoomId, reservation.BookingDate);
                var ResultCreatBooking = new ResultCreationBooking();
                var ListeDisponible = new List<Slot>();
                int startSlot=0;
                for (int i=0; i <= 23; i++)
                {
                    foreach (var currentVersion in currentReservations)
                    {
                        if(currentVersion.StartSlot == i)
                        {
                            if(i>0)
                            {
                                var slot = new Slot(startSlot,i-1);
                                ListeDisponible.Add(slot);
                                startSlot = currentVersion.EndSlot + 1;
                            }
                            //slot compris entre j et i-1 est c'est le slot disponible 
                            // après l'ajoute au slot de la liste dipo
                            //rénistialiser le j en chekc.EndSlot + 1 
                            //
                        }
                        else if (i == 23)
                        {
                            var slot = new Slot(startSlot, i);
                            ListeDisponible.Add(slot);
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

using System;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Classes;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Implementations {

    public class ReservationReadRepository : IReservationReadRepository {

        protected readonly AppDbContext context;

        public ReservationReadRepository(AppDbContext context) {
            this.context = context;
        }

        public async Task<Reservation> GetByRefNo(string refNo) {
            var reservation = context.Reservations
               .AsNoTracking()
               .Include(x => x.Customer)
               .Include(x => x.Destination)
               .Include(x => x.PickupPoint)
               .Include(x => x.Passengers).ThenInclude(x => x.Nationality)
               .Include(x => x.Passengers).ThenInclude(x => x.Occupant)
               .Include(x => x.Passengers).ThenInclude(x => x.Gender)
               .Where(x => x.RefNo.ToLower() == refNo.ToLower())
               .FirstOrDefaultAsync();
            return await reservation;
        }

        public async Task<Reservation> GetByDate(string date, int destinationId, string lastname, string firstname) {
            var reservation = context.Reservations
               .AsNoTracking()
               .Include(x => x.Customer)
               .Include(x => x.Destination)
               .Include(x => x.PickupPoint)
               .Include(x => x.Passengers).ThenInclude(x => x.Nationality)
               .Include(x => x.Passengers).ThenInclude(x => x.Occupant)
               .Include(x => x.Passengers).ThenInclude(x => x.Gender)
               .Where(x => x.Date == Convert.ToDateTime(date)
                    && x.DestinationId == destinationId
                    && x.Passengers.Any(x => x.Lastname.Trim().ToLower() == lastname.Trim().ToLower())
                    && x.Passengers.Any(x => x.Firstname.Trim().ToLower() == firstname.Trim().ToLower()))
                .FirstOrDefaultAsync();
            return await reservation;
        }

        public async Task<Reservation> GetById(string reservationId, bool includeTables) {
            return includeTables
                ? await context.Reservations
                    .AsNoTracking()
                    .Include(x => x.Customer)
                    .Include(x => x.PickupPoint)
                    .Include(x => x.Destination)
                    .Include(x => x.Passengers).ThenInclude(x => x.Nationality)
                    .Include(x => x.Passengers).ThenInclude(x => x.Occupant)
                    .Include(x => x.Passengers).ThenInclude(x => x.Gender)
                    .Where(x => x.ReservationId.ToString() == reservationId)
                    .SingleOrDefaultAsync()
                : await context.Reservations
                    .AsNoTracking()
                    .Include(x => x.Passengers)
                    .Where(x => x.ReservationId.ToString() == reservationId)
                    .SingleOrDefaultAsync();
        }

    }

}
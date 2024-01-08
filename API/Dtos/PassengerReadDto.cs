using System;
using API.Infrastructure.Classes;
using API.Infrastructure.Interfaces;

namespace API.Dtos {

    public class PassengerReadDto : IBaseEntity {

        // PK
        public int Id { get; set; }
        // FKs
        public Guid ReservationId { get; set; }
        // Fields
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Birthdate { get; set; }
        public string Remarks { get; set; }
        public string SpecialCare { get; set; }
        // Navigation
        public NationalityDto Nationality { get; set; }
        public SimpleEntity Gender { get; set; }

    }

    public class NationalityDto : SimpleEntity {

        public string Code { get; set; }

    }

}
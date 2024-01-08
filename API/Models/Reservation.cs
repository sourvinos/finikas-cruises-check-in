using System;
using System.Collections.Generic;
using API.Interfaces;

namespace API.Models {

    public class Reservation : IMetadata {

        // PK
        public Guid ReservationId { get; set; }
        // FKs
        public int CustomerId { get; set; }
        public int DestinationId { get; set; }
        public int? DriverId { get; set; }
        public int PickupPointId { get; set; }
        public int PortId { get; set; }
        public int? ShipId { get; set; }
        // Fields
        public DateTime Date { get; set; }
        public string RefNo { get; set; }
        public string TicketNo { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
        public int Free { get; set; }
        public int TotalPax { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Remarks { get; set; }
        // Metadata
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }
        // Navigation
        public Customer Customer { get; set; }
        public Destination Destination { get; set; }
        public PickupPoint PickupPoint { get; set; }
        public Port Port { get; set; }
        public List<Passenger> Passengers { get; set; }

    }

}
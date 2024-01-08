﻿using API.Infrastructure.Interfaces;

namespace API.Models {

    public class Customer : IBaseEntity {

        // PK
        public int Id { get; set; }
        // Fields
        public string Description { get; set; }

    }

}
using API.Infrastructure.Classes;

namespace API.ViewModels {

    public class DestinationDropdownVM : SimpleEntity {

        public bool IsPassportRequired { get; set; }
        public bool IsActive { get; set; }

    }

}
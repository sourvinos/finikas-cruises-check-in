using API.Dtos;
using API.Infrastructure.Helpers;
using FluentValidation;

namespace API.Validators {

    public class ReservationValidator : AbstractValidator<ReservationWriteDto> {

        public ReservationValidator() {
            // Passengers
            RuleForEach(x => x.Passengers).ChildRules(passenger => {
                passenger.RuleFor(x => x.GenderId).NotEmpty();
                passenger.RuleFor(x => x.NationalityId).NotEmpty();
                passenger.RuleFor(x => x.Lastname).NotEmpty().MaximumLength(128);
                passenger.RuleFor(x => x.Firstname).NotEmpty().MaximumLength(128);
                passenger.RuleFor(x => x.Birthdate).Must(DateHelpers.BeCorrectFormat);
                passenger.RuleFor(x => x.PassportExpireDate).Must(DateHelpers.BeEmptyOrValidDate);
                passenger.RuleFor(x => x.Remarks).MaximumLength(128);
                passenger.RuleFor(x => x.SpecialCare).MaximumLength(128);
            });
        }

    }

}
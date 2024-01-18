import { Injectable } from '@angular/core'
// Custom
import { PassengerWriteDto } from '../dtos/passenger-write-dto'
import { ReservationWriteDto } from '../dtos/reservation-write-dto'
import { DateHelperService } from 'src/app/shared/services/date-helper.service'
import { ReservationReadDto } from '../dtos/reservation-read-dto'

@Injectable({ providedIn: 'root' })

export class CheckInHelperService {

    constructor(private dateHelperService: DateHelperService) { }

    //#region public methods

    public flattenForm(reservation: ReservationReadDto): ReservationWriteDto {
        const x: ReservationWriteDto = {
            reservationId: reservation.reservationId,
            destinationId: reservation.destination.id,
            pickupPointId: reservation.pickupPoint.id,
            portId: 1,
            date: reservation.date,
            passengers: this.mapPassengers(reservation)
        }
        return x
    }

    //#endregion

    //#region private methods

    private mapPassengers(reservation: ReservationReadDto): PassengerWriteDto[] {
        const x = []
        reservation.passengers.forEach((passenger: any) => {
            const z: PassengerWriteDto = {
                reservationId: passenger.reservationId,
                genderId: passenger.gender.id,
                nationalityId: passenger.nationality.id,
                occupantId: 2,
                lastname: passenger.lastname,
                firstname: passenger.firstname,
                birthdate: this.dateHelperService.formatDateToIso(new Date(passenger.birthdate)),
                specialCare: passenger.specialCare,
                remarks: passenger.remarks
            }
            x.push(z)
        })
        return x
    }

    //#endregion

}

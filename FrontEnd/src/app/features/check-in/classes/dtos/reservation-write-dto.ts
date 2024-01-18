import { Guid } from 'guid-typescript'
// Custom
import { PassengerWriteDto } from './passenger-write-dto'

export interface ReservationWriteDto {

    // PK
    reservationId: Guid
    // Fields
    destinationId: number,
    pickupPointId: number,
    portId: number,
    date: string,
    passengers: PassengerWriteDto[]

}

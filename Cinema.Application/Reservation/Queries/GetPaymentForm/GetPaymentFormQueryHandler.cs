using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Reservation.Queries.GetPaymentForm
{
    public class GetPaymentFormQueryHandler : IRequestHandler<GetPaymentFormQuery, PaymentFormDto>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetPaymentFormQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<PaymentFormDto> Handle(GetPaymentFormQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            var paymentForm = new PaymentFormDto()
            {
                ReservationId = reservation.Id,
                TotalCost = reservation.TotalCost
            };

            return paymentForm;
        }
    }
}

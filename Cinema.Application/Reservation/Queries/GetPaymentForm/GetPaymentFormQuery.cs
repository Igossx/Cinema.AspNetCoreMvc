using MediatR;

namespace Cinema.Application.Reservation.Queries.GetPaymentForm
{
    public class GetPaymentFormQuery : IRequest<PaymentFormDto>
    {
        public Guid Id { get; set; }
    }
}

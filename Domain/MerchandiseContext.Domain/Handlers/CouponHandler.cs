using Shared;

namespace Domain.MerchandiseContext
{
    public class CouponHandler :
    IHandler<CreateCouponCommand>,
    IHandler<CreateExchangeCouponCommand>
    {
        private readonly ICouponRepository _repository;

        public CouponHandler(ICouponRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCouponCommand command)
        {
            var coupon = new Coupon(
                command.Value,
                command.Status,
                command.Type,
                command.Code,
                command.Date
            );

            if(command.CustomerId != null)
                coupon.CustomerId = command.CustomerId;

            _repository.CreateCoupon(coupon);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Cupom criado com sucesso", coupon);
        }

        public ICommandResult Handle(CreateExchangeCouponCommand command)
        {
            var coupon = new Coupon(
                command.Value,
                command.Status,
                command.Type,
                command.Code,
                command.Date
            );

            coupon.CustomerId = command.CustomerId;

            _repository.CreateCoupon(coupon);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Cupom de troca criado com sucesso", coupon);
        }
    }
}
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(X => X.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz ");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konuyu boş geçilemez ");
            RuleFor(X => X.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz ");
          RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli e-mail adresi yazınız.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayın");
        }
    }
}

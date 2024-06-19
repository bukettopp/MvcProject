﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(X => X.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz ");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konuyu boş geçilemez ");
            RuleFor(X => X.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz ");
            //RuleFor(x => x.ReceiverMail).EmailAddress(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayın");
        }
    }
}

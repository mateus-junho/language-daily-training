using LanguageDailyTraining.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageDailyTraining.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            Value = value;

            Validate();
        }

        private void Validate()
        {
            var invalidEmailMessage = "Invalid Email format";

            if (Value.Trim().EndsWith("."))
            {
                throw new DomainException(invalidEmailMessage);
            }
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(Value);
                AssertionConcerns.AssertArgumentEquals(mailAddress.Address, Value, invalidEmailMessage);
            }
            catch
            {
                throw new DomainException(invalidEmailMessage);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Helpers.Validation
{
    public class Validations<T> where T : class
    {
        private readonly List<string> _errors;

        private Validations()
        {
            _errors = new List<string>();
        }

        public static Validations<T> Build()
        {
            return new Validations<T>();
        }

        public Validations<T> When(bool condition, string message)
        {
            if (condition)
                _errors.Add(message);

            return this;
        }

        public void Thwros()
        {
            if (!_errors.Any()) return;

            new DomainException<T>().ThrowWithMessages(_errors);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreFinance.Domain.Helpers.Validation
{
    public class DomainException : Exception
    {
        private readonly Expression<Func<object, object>> _object = x => x;
        protected readonly IList<RuleViolation> _errors = new List<RuleViolation>();
        public IEnumerable<RuleViolation> Errors { get { return _errors; } }

        internal void AddError(string message)
        {
            _errors.Add(new RuleViolation { Property = _object, Message = message });
        }

        internal void AddErrors(IEnumerable<string> errors)
        {
            foreach (var erro in errors)
                AddError(erro);
        }

        public bool HasErrorWithMessage(string message)
        {
            return Errors.Any(RuleViolation => RuleViolation.Message.Equals(message));
        }

        public IEnumerable<string> Messages()
        {
            return Errors.Select(RuleViolation => RuleViolation.Message);
        }

        public override string Message
        {
            get { return ToString(); }
        }

        public string MessagensToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in Errors)
            {
                stringBuilder.Append(error.Message);
                stringBuilder.Append("\n");
            }
            return stringBuilder.Length > 0 ? stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString() : stringBuilder.ToString();
        }

        public override string ToString()
        {
            var text = new StringBuilder();
            foreach (var error in _errors)
                text.AppendLine(error.Message);

            return text.ToString();
        }
    }

    public class DomainException<TModel> : DomainException
    {
        internal void AdicionarErroPara<TProperty>(Expression<Func<TModel, TProperty>> property, string message)
        {
            _errors.Add(new RuleViolation { Property = property, Message = message });
        }
    }

    public static class RulesExceptionExtension
    {
        public static void ThrowWithMessages(this DomainException exception, IEnumerable<string> messages)
        {
            exception.AddErrors(messages);
            throw exception;
        }
    }
}

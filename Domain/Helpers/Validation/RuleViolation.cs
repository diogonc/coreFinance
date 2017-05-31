using System.Linq.Expressions;

namespace Domain.Helpers.Validation
{
    public class RuleViolation
    {
        public LambdaExpression Property { get; internal set; }
        public string Message { get; internal set; }
    }
}
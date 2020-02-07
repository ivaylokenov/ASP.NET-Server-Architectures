namespace Blog.Application.Common.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation.Results;

    public class ModelValidationException : Exception
    {
        public ModelValidationException()
            : base("One or more validation failures have occurred.") 
            => this.Failures = new Dictionary<string, string[]>();

        public ModelValidationException(List<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                this.Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}

namespace Blog.Application.Common.Behaviours
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using FluentValidation;
    using MediatR;

    public class RequestValidationBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
            => this.validators = validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            
            var failures = this
                .validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ModelValidationException(failures);
            }

            return next();
        }
    }
}
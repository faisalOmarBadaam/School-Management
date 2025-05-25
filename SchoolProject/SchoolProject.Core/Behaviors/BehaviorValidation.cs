using FluentValidation;
using MediatR;
using SchoolProject.Data.Exceptions;

namespace SchoolProject.Core.Behaviors
{
    public class BehaviorValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public BehaviorValidation(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators.Select(async x => await x.ValidateAsync(context))
                .SelectMany(x => x.Result.Errors)
                .Where(x => x is not null)
                .GroupBy(
                x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                x => x.ErrorMessage,
                (propartyName, ErrorMessage) => new
                {
                    key = propartyName,
                    value = ErrorMessage.Distinct().ToArray()
                }
                ).ToDictionary(x => x.key, x => x.value);

            if (errorsDictionary.Count != 0)
                throw new ValidationAppException(errorsDictionary);

            return await next();


        }
    }
}

namespace Practical25.Application.Behaviours;

// This class is a MediatR pipeline behavior that performs validation on incoming
// requests using FluentValidation.
public class ValidationBehaviour<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators
        = validators;

    /// <summary>
    /// Validates requests before executing their handlers.
    /// </summary>
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var context =
            new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}

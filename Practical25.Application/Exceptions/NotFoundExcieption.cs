namespace Practical25.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    public NotFoundException(string message) : base(message)
    {
    }
}

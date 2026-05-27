namespace Practical25.Application.Exceptions;

public sealed class NotFoundException(string message) : Exception(message)
{
}

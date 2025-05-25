namespace SchoolProject.Data.Exceptions
{
    public class BadInputException(string message) : Exception(message)
    {
    }

    public class NotFoundException(string message) : Exception(message)
    {
    }

    public class UnauthorizedException(string message) : Exception(message)
    {
    }
    public class ValidationAppException(IReadOnlyDictionary<string, string[]> Errors) : Exception("one or more validation error occured")
    {
        public IReadOnlyDictionary<string, string[]> Errors = Errors;
    }
}

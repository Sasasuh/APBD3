namespace ContainersAPBD.Exceptions;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}
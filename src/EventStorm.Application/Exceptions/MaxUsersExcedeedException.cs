namespace EventStorm.Application.Exceptions
{
    public class MaxUsersExcedeedException : Exception
    {
        public MaxUsersExcedeedException(string message) : base(message)
        {

        }
    }
}
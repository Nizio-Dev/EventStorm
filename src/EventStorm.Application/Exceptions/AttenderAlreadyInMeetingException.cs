namespace EventStorm.Application.Exceptions
{
    public class AttenderAlreadyInMeetingException : Exception
    {
        public AttenderAlreadyInMeetingException(string message) : base(message)
        {

        }
    }
}
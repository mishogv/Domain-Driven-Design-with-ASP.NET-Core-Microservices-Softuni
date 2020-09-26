namespace BusinessCards.Domain.Exceptions
{
    public class InvalidUsernameException : BaseDomainException
    {
        public InvalidUsernameException()
        {
        }


        public InvalidUsernameException(string message) => this.Error = message;
    }
}

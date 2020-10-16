namespace BCSystem.Domain.BusinessCards.Exceptions
{
    using Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string error) => Error = error;
    }
}
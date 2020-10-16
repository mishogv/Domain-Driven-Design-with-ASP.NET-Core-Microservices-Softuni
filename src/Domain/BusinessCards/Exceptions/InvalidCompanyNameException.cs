namespace BCSystem.Domain.BusinessCards.Exceptions
{
    using BCSystem.Domain.Common;

    public class InvalidCompanyNameException : BaseDomainException
    {
        public InvalidCompanyNameException()
        {
        }

        public InvalidCompanyNameException(string error) => Error = error;
    }
}

namespace BCSystem.Domain.BusinessCards.Exceptions
{
    using BCSystem.Domain.Common;

    public class InvalidDescriptionException : BaseDomainException
    {
        public InvalidDescriptionException()
        {
        }

        public InvalidDescriptionException(string error) => this.Error = error;
    }
}

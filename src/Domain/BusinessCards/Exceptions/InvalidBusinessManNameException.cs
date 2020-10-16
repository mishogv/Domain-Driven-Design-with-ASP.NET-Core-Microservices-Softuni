namespace BCSystem.Domain.BusinessCards.Exceptions
{
    using BCSystem.Domain.Common;

    public class InvalidBusinessManNameException : BaseDomainException
    {
        public InvalidBusinessManNameException()
        {
        }

        public InvalidBusinessManNameException(string error) => this.Error = error;
    }
}

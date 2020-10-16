namespace BCSystem.Application.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int businessManId)
        {
            this.Token = token;
            this.BusinessManId = businessManId;
        }

        public int BusinessManId { get; }

        public string Token { get; }
    }
}

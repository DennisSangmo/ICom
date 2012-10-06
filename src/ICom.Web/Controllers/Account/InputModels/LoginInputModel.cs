using System.ComponentModel;

namespace ICom.Web.Controllers.Account.InputModels
{
    public class LoginInputModel
    {
        [DisplayName("Användarnamn")]
        public string UserName { get; set; }

        [DisplayName("Lösenord")]
        public string Password { get; set; }
    }
}
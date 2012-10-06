using ICom.Web.Controllers.Account.InputModels;

namespace ICom.Web.Controllers.Account.ViewModels
{
    public class LoginViewModel
    {
        public LoginInputModel InputModel { get; set; }

        public LoginViewModel()
        {
            InputModel = new LoginInputModel();
        } 
    }
}
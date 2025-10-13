using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using ClubMembershipApplication.Views;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView(ILogin login) : IView
    {
        ILogin login = login;
        public IFieldValidator FieldValidator => FieldValidator;

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");

            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password");

            string password = Console.ReadLine();

            User user = login.Login(emailAddress, password);

            if (user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
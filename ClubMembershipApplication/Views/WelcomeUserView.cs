using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Views
{
    public class WelcomeUserView: IView 
    {
        User user = null;

        public WelcomeUserView(User user)
        {
            this.user = user;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {

            Console.Clear();
            CommonOutputText.WriteMainHeading();

            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"{user.FirstName} !! {Environment.NewLine} Welcome to the Cycling Club!.");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}
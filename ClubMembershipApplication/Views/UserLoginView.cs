using ClubMembershipApplication.Views;

namespace ClubMembershipApplication
{
    public static class UserLoginView(ILogin login) : IView
    {
        ILogin login = null;
        IFieldValidator FieldValidator => null;

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
                // ToDo: Run Welcome View
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match our records");
                CommonOutputFormat.ChangeFontColor(FormatTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
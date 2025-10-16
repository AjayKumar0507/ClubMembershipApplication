using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication
{
    public class MainView(IView registerView, IView loginView) : IView
    {
        public IFieldValidator FieldValidator => null;

        IView registerView = registerView;
        IView loginView = loginView;


        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or if you not registered yet please press 'r'");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunUserLoginView();
            }
            else if (key == ConsoleKey.L)
            {
                RunUserLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.Read();
            }
        }

        private void RunUserRegistrationView()
        {
            registerView.RunView();
        }

        private void RunUserLoginView()
        {
            loginView.RunView();
        }
    }
}

using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication
{
    public  interface IView
    {
        void RunView();
        IFieldValidator FieldValidator{ get; }
    }
}
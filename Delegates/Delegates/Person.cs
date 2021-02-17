namespace Delegates
{
    public class Person
    {
        private string firstName;

        public Person(string firstName)
            => this.firstName = firstName;

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }
    }
}

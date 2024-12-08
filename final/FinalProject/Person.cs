public class Person
{
    private string _firstName;
    private string _lastName;

    public Person(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("First and last names cannot be empty.");
        }
        _firstName = firstName;
        _lastName = lastName;
    }

    public string GetFullName() => $"{_firstName} {_lastName}";

    public string FirstName => _firstName; // Optional read-only property
    public string LastName => _lastName;  // Optional read-only property
}

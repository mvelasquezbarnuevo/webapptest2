
using System.Collections.Generic;

namespace PhoneBookTestApp.Abstractions
{
    public interface IPhoneBook
    {
        Person findPerson(string firstName, string lastName);
        void addPerson(Person newPerson);
        List<Person> GetPersons();
    }
}
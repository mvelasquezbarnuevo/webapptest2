using PhoneBookTestApp.Abstractions;
using System;
using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class WorkHandler : IWorkHandler
    {
        private readonly IPhoneBook _phoneBook;

        public WorkHandler(IPhoneBook phoneBook)
        {
            _phoneBook = phoneBook ?? throw new ArgumentNullException(nameof(phoneBook));

        }

        public void DoWork()
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                AddPersonsToPhoneBook();
                PrintPhoneBook();
                FindAndPrint("Cynthia", "Smith");


            }
            catch (Exception)
            {

                //some logging stuff can be added here
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }


        }

        private void FindAndPrint(string name, string lastName)
        {
            Console.WriteLine("**Find person**");
            var person = _phoneBook.findPerson(name, lastName);
            if (person != null) {
                PrintPerson(person);
            }
        }

        private void PrintPhoneBook() {
            Console.WriteLine("**Print all**");
            List<Person> persons = _phoneBook.GetPersons();
            foreach (var person in persons)
            {
                PrintPerson(person);
            }
        }

        private void PrintPerson(Person person)
        {
            
            Console.WriteLine($"Name:{person.name}, Phone:{person.phoneNumber}, Address: {person.address}");
        }

        private void AddPersonsToPhoneBook()
        {
            _phoneBook.addPerson(new Person
            {
                name = "John Smith",
                address = "1234 Sand Hill Dr, Royal Oak, MI",
                phoneNumber = "(248) 123-4567"
            });

            _phoneBook.addPerson(new Person
            {
                name = "Cynthia Smith",
                address = "875 Main St, Ann Arbor, MI",
                phoneNumber = "(824) 128-8758"
            });
        }
    }
}

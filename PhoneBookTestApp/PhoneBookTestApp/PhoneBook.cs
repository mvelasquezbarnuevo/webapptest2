using PhoneBookTestApp.Abstractions;
using System;
using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        private readonly IDbAccess _dbAccess;

        public PhoneBook(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess ?? throw new System.ArgumentNullException(nameof(dbAccess));
        }

        public void addPerson(Person newPerson)
        {
            using (var access = _dbAccess)
            {
                access.Add(newPerson);
            }
        }

        public Person findPerson(string firstName, string lastName)
        {
            using (var access = _dbAccess)
            {
                return access.Find($"{firstName} {lastName}");
            }
                
        }

        public List<Person> GetPersons()
        {
            using (var access = _dbAccess)
            {
                return access.GetAll();
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace PhoneBookTestApp.Abstractions

{
    public interface IDbAccess : IDisposable
    {
        void Add(Person newPerson);
        Person Find(string name);
        List<Person> GetAll();
    }
}
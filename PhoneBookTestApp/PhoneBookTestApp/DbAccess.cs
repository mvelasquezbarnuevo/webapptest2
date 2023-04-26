using PhoneBookTestApp.Abstractions;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class DbAccess : IDbAccess
    {
        
        private SQLiteConnection _dbConnection;
        public DbAccess(string connString)
        {
            _dbConnection = new SQLiteConnection(connString);

        }
        public void Add(Person newPerson)
        {
            _dbConnection.Open();
            var command =
                    new SQLiteCommand(
                        $"INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('{newPerson.name}'," +
                        $"'{newPerson.phoneNumber}', '{newPerson.address}')",
                        _dbConnection);
            command.ExecuteNonQuery();
           
        }

        public void Dispose()
        {
            _dbConnection.Close();
        }

        public Person Find(string name)
        {
            _dbConnection.Open();
            var person = new Person();
            var command =
                    new SQLiteCommand($"SELECT * FROM PHONEBOOK WHERE NAME = '{name}'", _dbConnection);


            var datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                person = new Person
                {
                    name = datareader.GetString(0),
                    phoneNumber = datareader.GetString(1),
                    address = datareader.GetString(2)
                };


            }

            return person;
        }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            _dbConnection.Open();
            var command =
                    new SQLiteCommand("SELECT * FROM PHONEBOOK", _dbConnection);


            var datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                var person = new Person
                {
                    name = datareader.GetString(0),
                    phoneNumber = datareader.GetString(1),
                    address = datareader.GetString(2)
                };
                persons.Add(person);

            }

            return persons;
        }
    }
}

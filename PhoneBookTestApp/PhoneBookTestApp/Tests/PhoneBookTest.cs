using FakeItEasy;
using NUnit.Framework;
using PhoneBookTestApp;
using PhoneBookTestApp.Abstractions;
using System;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming


    [TestFixture]
    public class PhoneBookTest
    {
        private IDbAccess _dbAccess;
        private readonly PhoneBook _phoneBook;

        public PhoneBookTest()
        {
            _dbAccess = A.Fake<IDbAccess>();
            _phoneBook = new PhoneBook(_dbAccess);
        }

        [Test]
        public void addPerson()
        {
            // arrange
            var person = new Person();
            var addMethod = A.CallTo(() => _dbAccess.Add(person));

            //act
            _phoneBook.addPerson(person);

            //assert
            addMethod.MustHaveHappenedOnceExactly();

        }

        [Test]
        public void findPerson()
        {
            // arrange
            var person = new Person()
            {
                name = "name lastname"
            };
            var findMethod = A.CallTo(() => _dbAccess.Find(A<string>.Ignored));
            findMethod.Returns(person);

            //act
            var personResult = _phoneBook.findPerson("name", "lastname");

            //assert
            findMethod.MustHaveHappenedOnceExactly();
            Assert.AreEqual(personResult.name, person.name);
        }

        [Test]
        public void NullDbAccess_ShouldThrow_AnException()
        {

            Assert.Throws<ArgumentNullException>(() => new PhoneBook(null));
        }
    }

    // ReSharper restore InconsistentNaming 
}
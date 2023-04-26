using PhoneBookTestApp.Abstractions;
using PhoneBookTestApp.Infrastucture;
using System;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = Boostrap.Load();

            var workHandler = resolver.Resolve<IWorkHandler>();

            workHandler.DoWork();
            Console.ReadLine();

            //try
            //{
            //    DatabaseUtil.initializeDatabase();
            //    /* TODO: create person objects and put them in the PhoneBook and database
            //    * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
            //    * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
            //    */

            //    // TODO: print the phone book out to System.out
            //    // TODO: find Cynthia Smith and print out just her entry
            //    // TODO: insert the new person objects into the database

            //}
            //finally
            //{
            //    DatabaseUtil.CleanUp();
            //}
        }
    }
}

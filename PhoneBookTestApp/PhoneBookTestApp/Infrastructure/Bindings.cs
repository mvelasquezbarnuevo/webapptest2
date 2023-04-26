using Ninject.Modules;
using PhoneBookTestApp.Abstractions;
using System.Configuration;

namespace PhoneBookTestApp.Infrastucture
{
    public class Bindings : NinjectModule
    {
        private static string ConnectionString = ConfigurationManager.AppSettings["SqLiteConnectionString"];
        public override void Load()
        {
            Bind<IWorkHandler>().To<WorkHandler>();
            Bind<IDbAccess>().ToConstructor(ctor => new DbAccess(ConnectionString));
            Bind<IPhoneBook>().To<PhoneBook>();
        }
    }
}

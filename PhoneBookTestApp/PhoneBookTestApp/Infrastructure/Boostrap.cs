using Ninject;
using PhoneBookTestApp.Infrastructure;
using System.Reflection;

namespace PhoneBookTestApp.Infrastucture
{
    public static class Boostrap
    {
        public static IDependencyResolver Load()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return new DependencyResolver(kernel);
        }
    }
}

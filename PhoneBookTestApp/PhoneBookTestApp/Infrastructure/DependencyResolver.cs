using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly StandardKernel _kernel;

        public DependencyResolver(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }
    }
}

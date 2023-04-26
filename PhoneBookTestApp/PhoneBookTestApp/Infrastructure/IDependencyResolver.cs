namespace PhoneBookTestApp.Infrastructure
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
}
public class CustomDependencyInjector
{
    private readonly IList<Type> _RegisteredTypes = new List<Type>();

    public void Add<I, C>()
    {
        if (typeof(I).IsAssignableFrom(typeof(C)))
        {
            Type type = typeof(I);
            _RegisteredTypes.Add(type);
        }
    }

    public T Get<T>()
    {
        if (!_RegisteredTypes.Contains(typeof(T)))
        {
            throw new InvalidOperationException("Type is not dependency injected");
        }

        var type = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .First(c => typeof(T).IsAssignableFrom(c) && c.BaseType != null);

        return (T)type.GetConstructor(new Type[0]).Invoke(new object[0]);
    }

    public void Dispose<T>() => _RegisteredTypes.Remove(typeof(T));
}
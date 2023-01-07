public class CustomDependencyInjector
{
    private readonly IList<(Type,Type)> _RegisteredTypes = new List<(Type,Type)>();

    public void Add<I, C>()
    {
        if (typeof(I).IsAssignableFrom(typeof(C)))
        {
            Type interfaceType = typeof(I);
            Type classType = typeof(C);
            _RegisteredTypes.Add((interfaceType, classType));
        }
    }

    public T Get<T>()
    {
        var classType = _RegisteredTypes.FirstOrDefault(t => t.Item1 == typeof(T));
        if (classType.Item1 == null)
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
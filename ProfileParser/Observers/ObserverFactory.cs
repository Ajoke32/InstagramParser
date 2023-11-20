namespace ProfileParser.Observers;

public class ObserverFactory
{
    private static readonly Dictionary<Type, object> Instances = new ();
    public static IObserver<TData> CreateObserver<TObserver,TData>()
    {
        var type = typeof(TObserver);
        var instance = Activator.CreateInstance(type);
        if (instance == null)
        {
            throw new Exception("Observable not exist");
        }

        if (Instances.ContainsKey(typeof(TObserver)))
        {
            return (IObserver<TData>)Instances[type];
        }
        
        Instances[type] = instance;
        
        return (IObserver<TData>)instance;
    }
}
namespace ProfileParser.Observers;

public class DataObserver<TContext>:IObserver<TContext>
{
    
    public void Execute(Func<TContext> dataDelegate,Action<TContext> action)
    {
        var data = dataDelegate();
        action(data);
    }
}
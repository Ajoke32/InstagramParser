namespace ProfileParser.Observers;

public interface IObserver<TContext>
{
    public void Execute(Func<TContext> dataDelegate,Action<TContext> action);
}
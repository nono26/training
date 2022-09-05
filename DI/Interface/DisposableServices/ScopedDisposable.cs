namespace DI.Interface.DisposableServices
{
    public class ScopedDisposable : IDisposable
    {
    public void Dispose() => Console.WriteLine($"{nameof(ScopedDisposable)}.Dispose()");
        
    }
}
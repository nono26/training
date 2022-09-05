namespace DI.Interface.DisposableServices
{
    public class SingletonDisposable: IDisposable
    {
        public void Dispose() => Console.WriteLine($"{nameof(SingletonDisposable)}.Dispose()");

    }
}
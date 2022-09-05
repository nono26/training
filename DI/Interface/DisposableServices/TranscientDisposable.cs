namespace DI.Interface.DisposableServices
{
    public class TranscientDisposable:IDisposable
    {
        public void Dispose()=> Console.WriteLine($"{nameof(TranscientDisposable)}.Dispose()");
    }
}
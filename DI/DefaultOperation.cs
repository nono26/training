using static System.Guid;

namespace DI.Example;

public class DefaultOperation:
    ITransientOperation,
    IScopedOperation,
    ISingletonOperation{
        public string OperationId{get;} = NewGuid().ToString()[^4..];
    }
namespace CSharpFun.MethodCalling;

internal class FooClass
{
    public PointClass PointClass { get; set; } = new();

    private PointStruct _pointStruct;
    public PointStruct PointStruct
    {
        get => _pointStruct;
        set => _pointStruct = value;
    }
    public ref PointStruct PointStructRef => ref _pointStruct;
    
    public override string ToString()
    {
        return $"{nameof(FooClass)} | {nameof(PointClass)}: {PointClass}, {nameof(PointStruct)}: {PointStruct}";
    }
}

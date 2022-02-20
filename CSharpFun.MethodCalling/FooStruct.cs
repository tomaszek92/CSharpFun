namespace CSharpFun.MethodCalling;

internal struct FooStruct
{
    public PointClass PointClass { get; set; }
    public PointStruct PointStruct { get; set; }

    public override string ToString()
    {
        return $"{nameof(FooStruct)} | {nameof(PointClass)}: {PointClass}, {nameof(PointStruct)}: {PointStruct}";
    }
}
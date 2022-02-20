namespace CSharpFun.MethodCalling;

internal struct PointStruct
{
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"{nameof(PointStruct)} | {nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }
}
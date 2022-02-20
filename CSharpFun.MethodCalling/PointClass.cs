namespace CSharpFun.MethodCalling;

internal class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public override string ToString()
    {
        return $"{nameof(PointClass)} | {nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }
}
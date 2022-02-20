using CSharpFun.MethodCalling;

var pc = new PointClass { X = 1, Y = 1 };
var ps = new PointStruct { X = 1, Y = 1 };
Console.WriteLine(pc);
Console.WriteLine(ps);

UpdatePointClass(pc);
UpdatePointStruct(ps);
Console.WriteLine(pc);
Console.WriteLine(ps);

ResetPointClassRef(ref pc);
ResetPointStructRef(ref ps);
Console.WriteLine(pc);
Console.WriteLine(ps);

ResetPointClassOut(out pc);
ResetPointStructOut(out ps);
Console.WriteLine(pc);
Console.WriteLine(ps);

var fc = new FooClass
{
    PointClass = new PointClass { X = 1, Y = 1 }, 
    PointStruct = new PointStruct { X = 1, Y = 1 },
};

var fs = new FooStruct
{
    PointClass = new PointClass { X = 1, Y = 1 }, 
    PointStruct = new PointStruct { X = 1, Y = 1 },
};
Console.WriteLine(fc);
Console.WriteLine(fs);

UpdateFooClass(fc);
UpdateFooStruct(fs);
Console.WriteLine(fc);
Console.WriteLine(fs);

UpdateFooClass2(fc);
UpdateFooStruct2(fs);
Console.WriteLine(fc);
Console.WriteLine(fs);

void UpdatePointClass(PointClass pointClass)
{
    pointClass.X = 2;
    pointClass.Y = 2;
}

void ResetPointClassRef(ref PointClass pointClass)
{
    pointClass = new PointClass { X = 3, Y = 3 };
}

void ResetPointClassOut(out PointClass pointClass)
{
    pointClass = new PointClass { X = 4, Y = 4 };
}

void UpdatePointStruct(PointStruct pointStruct)
{
    pointStruct.X = 2;
    pointStruct.Y = 2;
}

void ResetPointStructRef(ref PointStruct pointStruct)
{
    pointStruct = new PointStruct { X = 3, Y = 3 };
}

void ResetPointStructOut(out PointStruct pointStruct)
{
    pointStruct = new PointStruct { X = 4, Y = 4 };
}

void UpdateFooClass(FooClass fooClass)
{
    fooClass.PointClass = new PointClass { X = 2, Y = 2 };
    fooClass.PointStruct = new PointStruct { X = 2, Y = 2 };
}

void UpdateFooStruct(FooStruct fooStruct)
{
    fooStruct.PointClass = new PointClass { X = 2, Y = 2 };
    fooStruct.PointStruct = new PointStruct { X = 2, Y = 2 };
}

void UpdateFooClass2(FooClass fooClass)
{
    fooClass.PointClass.X = 3;
    fooClass.PointClass.Y = 3;
    ref var pointStruct = ref fooClass.PointStructRef;
    pointStruct.X = 3;
    pointStruct.Y = 3;
}

void UpdateFooStruct2(FooStruct fooStruct)
{
    fooStruct.PointClass.X = 3;
    fooStruct.PointClass.Y = 3;
    // fooStruct.PointStruct.X = 2;
    // fooStruct.PointStruct.Y = 2;
}
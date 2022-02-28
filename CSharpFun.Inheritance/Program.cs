BaseWithVirtual @base = new DerivedBaseWithVirtual();
@base.ShowMsg();

new DerivedBaseWithVirtual().ShowMsg();

Base base1 = new DerivedBase();
base1.ShowMsg();

Base base2 = new DerivedBaseNew();
base2.ShowMsg();

new DerivedBase().ShowMsg();
new DerivedBaseNew().ShowMsg();

public class BaseWithVirtual
{
    public virtual void ShowMsg()
    {
        Console.WriteLine("BaseWithVirtual");
    }
}

public class Base
{
    public void ShowMsg()
    {
        Console.WriteLine("Base");
    }
}

public class DerivedBaseWithVirtual : BaseWithVirtual
{
    public override void ShowMsg()
    {
        Console.WriteLine("DerivedBaseWithVirtual");
    }
}

public class DerivedBase : Base
{
    public void ShowMsg()
    {
        Console.WriteLine("DerivedBase");
    }
}

public class DerivedBaseNew : Base
{
    public new void ShowMsg()
    {
        Console.WriteLine("DerivedBaseNew");
    }
}
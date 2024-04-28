using CsBindgen;

namespace PhysisSharp;

public class Class1
{
    public int Add(int a, int b)
    {
        return NativeMethods.my_add(a, b);
    }
}

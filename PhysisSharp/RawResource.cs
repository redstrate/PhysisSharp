using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CsBindgen;

namespace PhysisSharp;

public class RawResource
{
    private readonly physis_Buffer _buffer;
    
    public unsafe Span<byte> Data => MemoryMarshal.CreateSpan(ref Unsafe.AsRef<byte>(_buffer.data), (int)_buffer.size);
    
    internal RawResource(physis_Buffer buffer)
    {
        _buffer = buffer;
    }
}
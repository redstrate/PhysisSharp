using CsBindgen;

namespace PhysisSharp;

public class GameData
{
    private unsafe CsBindgen.GameData* _ptr;
    
    public GameData(String path)
    {
        unsafe
        {
            fixed (char* p = path)
            {
                var s = HelperMethods.csharp_to_c_string((ushort*)p, path.Length);
                _ptr = NativeMethods.physis_gamedata_initialize(s);
                if (_ptr == null)
                {
                    throw new Exception("Invalid game directory");
                }
            }
        }
    }

    public RawResource? Extract(String path)
    {
        unsafe
        {
            fixed (char* p = path)
            {
                var s = HelperMethods.csharp_to_c_string((ushort*)p, path.Length);
                var buffer = NativeMethods.physis_gamedata_extract_file(_ptr, s);
                return buffer.data == null ? null : new RawResource(buffer);
            }
        }
    }
}

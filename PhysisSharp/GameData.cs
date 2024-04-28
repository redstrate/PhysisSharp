using CsBindgen;

namespace PhysisSharp;

public class GameData
{
    public GameData(String path)
    {
        unsafe
        {
            fixed (char* p = path)
            {
                var s = HelperMethods.csharp_to_c_string((ushort*)p, path.Length);
                var ptr = CsBindgen.NativeMethods.physis_gamedata_initialize(s);
                Console.WriteLine((IntPtr)ptr);

                var repositories = NativeMethods.physis_gamedata_get_repositories(ptr);
                Console.WriteLine($"Read {repositories.repositories_count} repositories.");
            }
        }
    }
}

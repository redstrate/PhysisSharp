# PhysisSharp

C# bindings for Physis.

## Building

Due to the complex nature of the build process, I have included a helper script called `build.sh`. If you wish to build it manually, see the script as it's very simple.

## Running the example

Note that the build script nor do any of the build steps copy the .so or .dll manually. You need to make sure to have `libphysis.so`, `libPhysisSharpHelpers.so` and `libPhysisSharp.so` (replace with `.dll` on Windows) next to the executable.

You can also use `LD_LIBRARY_PATH` on Linux to fool the linker.

## Process

[Physis](https://github.com/redstrate/Physis) is a Rust library for reading and writing FFXIV data. PhysisSharp exposes C# bindings that can be used in any C# application on Windows or Linux.

1. Physis is wrapped in libphysis, which exposes it on the C FFI.
2. bindgen is called on the generated libphysis header. It creates a bindgen-compatible Rust file that can be used for other tools.
3. csbindgen uses this newly created Rust file to create a C# FFI layer.
4. PhysisSharp has a hand-written safe layer over this C# FFI that can be used by other applications.

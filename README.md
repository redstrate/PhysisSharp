# PhysisSharp

C# bindings for Physis.

## Running the example

Make sure the .dll or .so file is located where you run the application. If you need to test quickly, set the `LD_LIBRARY_PATH` on Linux.

## Process

[Physis](https://github.com/redstrate/Physis) is a Rust library for reading and writing FFXIV data. PhysisSharp exposes C# bindings that can be used in any C# application on Windows or Linux.

1. Physis is wrapped in libphysis, which exposes it on the C FFI.
2. bindgen is called on the generated libphysis header. It creates a bindgen-compatible Rust file that can be used for other tools.
3. csbindgen uses this newly created Rust file to create a C# FFI layer.
4. PhysisSharp has a hand-written safe layer over this C# FFI that can be used by other applications.

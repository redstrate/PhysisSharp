fn main() {
    csbindgen::Builder::default()
        .input_extern_file("src/lib.rs")
        .csharp_dll_name("PhysisSharp")
        .generate_csharp_file("../PhysisSharp/NativeMethods.cs")
        .unwrap();
}

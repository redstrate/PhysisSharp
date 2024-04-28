fn main() {
    // Turn the generated C physis header into a bindgen file
    bindgen::Builder::default()
        .header("../libphysis/target/public/physis.hpp")
        .generate().unwrap()
        .write_to_file("physis.rs").unwrap();

    // Feed it into csbindgen, which then turns it into C# bindings
    csbindgen::Builder::default()
        .input_bindgen_file("physis.rs")
        .rust_file_header("use super::physis::*;")
        .csharp_dll_name("physis")
        .generate_to_file("physis_ffi.rs", "../PhysisSharp/NativeMethods.g.cs")
        .unwrap();

    // And then do the same for our helper methods specifically for C#
    csbindgen::Builder::default()
        .input_extern_file("src/lib.rs")
        .rust_file_header("use super::physis::*;")
        .csharp_class_name("HelperMethods")
        .csharp_dll_name("PhysisSharpHelpers")
        .generate_to_file("physis_helper.rs", "../PhysisSharp/HelperMethods.g.cs")
        .unwrap();
}

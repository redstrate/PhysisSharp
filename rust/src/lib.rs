// lib.rs, simple FFI code

use std::ffi::{c_char, CString};
use std::ptr::null;

#[no_mangle]
pub unsafe extern "C" fn csharp_to_c_string(utf16_str: *const u16, utf16_len: i32) -> *const c_char {
    let slice = std::slice::from_raw_parts(utf16_str, utf16_len as usize);
    let str = String::from_utf16(slice).unwrap();

    let s = CString::new(str.as_bytes());

    match s {
        Ok(x) => x.into_raw(),
        Err(_) => null(),
    }
}